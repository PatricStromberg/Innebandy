using System;
using System.Collections.Generic;

namespace Innebandy.Models
{
    public class TournamentRound
    {
        public string type { get; set; }
        public int number { get; set; }
    }

    public class Competitor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string abbreviation { get; set; }
        public string qualifier { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public string city_name { get; set; }
        public string country_name { get; set; }
        public string map_coordinates { get; set; }
        public string country_code { get; set; }
        public int? capacity { get; set; }
    }

    public class SportEvent
    {
        public string id { get; set; }
        public DateTime scheduled { get; set; }
        public bool start_time_tbd { get; set; }
        public TournamentRound tournament_round { get; set; }
        public Season season { get; set; }
        public Tournament tournament { get; set; }
        public IList<Competitor> competitors { get; set; }
        public Venue venue { get; set; }
    }

    public class PeriodScore
    {
        public int home_score { get; set; }
        public int away_score { get; set; }
        public string type { get; set; }
        public int number { get; set; }
    }

    public class SportEventStatus
    {
        public string status { get; set; }
        public string match_status { get; set; }
        public int home_score { get; set; }
        public int away_score { get; set; }
        public string winner_id { get; set; }
        public IList<PeriodScore> period_scores { get; set; }
    }

    public class Result
    {
        public SportEvent sport_event { get; set; }
        public SportEventStatus sport_event_status { get; set; }
    }

    public class SSLResult
    {
        public DateTime generated_at { get; set; }
        public string schema { get; set; }
        public Tournament tournament { get; set; }
        public IList<Result> results { get; set; }
    }
}
