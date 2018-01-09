using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innebandy.Models;
using Innebandy.Services;

namespace Innebandy
{
    public class FloorballManager
    {
        ApiService apiService;

        public FloorballManager(ApiService service)
        {
            apiService = service;
        }

        public Task<IList<TeamStanding>> GetStandings(string type)
        {
            return apiService.GetStandings(type);
        }

        public Task<IList<Result>> GetResults()
        {
            return apiService.GetResults();
        }

        public async Task<List<RoundNumber>> GetRounds()
        {
            var results = await GetResults();

            var roundList = new List<Round>();

            foreach (var round in results)
            {
                var newRound = new Round();

                foreach (var team in round.sport_event.competitors)
                {
                    switch (team.qualifier)
                    {
                        case "home":
                            newRound.home_team_name = team.name;
                            break;
                        case "away":
                            newRound.away_team_name = team.name;
                            break;
                    }
                }

                newRound.home_team_score = round.sport_event_status.home_score;
                newRound.away_team_score = round.sport_event_status.away_score;

                switch (round.sport_event_status.match_status)
                {
                    case "ended":
                        break;
                    case "aet" when round.sport_event_status.home_score > round.sport_event_status.away_score:
                        newRound.home_team_exclusion = "SD";
                        break;
                    case "aet" when round.sport_event_status.home_score < round.sport_event_status.away_score:
                        newRound.away_team_exclusion = "SD";
                        break;
                    case "ap" when round.sport_event_status.home_score > round.sport_event_status.away_score:
                        newRound.home_team_exclusion = "ST";
                        break;
                    case "ap" when round.sport_event_status.home_score < round.sport_event_status.away_score:
                        newRound.away_team_exclusion = "ST";
                        break;
                }

                newRound.number = round.sport_event.tournament_round.number;

                roundList.Add(newRound);
            }

            var roundNumberList = Separat(roundList);

            return roundNumberList;
        }

        public List<RoundNumber> Separat(List<Round> source)
        {
            var roundNumberList = new List<RoundNumber>();

            int max = source.Max(c => c.number);
            int min = source.Min(c => c.number);

            for (int i = min; i <= max; i++)
            {
                var item = source.Where(c => c.number == i).ToList();
                if (item.Count > 0)
                {
                    var roundNumb = new RoundNumber();
                    roundNumb.Title = $"Omgång {i}";
                    roundNumb.AddRange(item);
                    roundNumberList.Add(roundNumb);
                }
                    
            }

            return roundNumberList;
        }

    }
}
