using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Innebandy.Models;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;

namespace Innebandy.Services
{
    public class ApiService
    {
        HttpClient client;

        public ApiService()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
        }       

        public async Task<IList<TeamStanding>> GetStandings(string type)
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.sportradar.com/floorball-t1/sv/tournaments/sr:tournament:255/standings.json?api_key=xsbpbssr445356pmrrewsz5a"),
                Method = HttpMethod.Get
            };

            var response = await client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var parsedData = JsonConvert.DeserializeObject<SSLStanding>(data).standings;

                foreach (var standing in parsedData)
                {
                    if (standing.type == type)
                    {
                        foreach (var groups in standing.groups)
                        {
                            return await Task.FromResult(groups.team_standings);
                        }
                    }

                }
            }

            return null;
        }

        //public async Task<IList<Result>> GetResults()
        //{
        //    var req = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("http://api.sportradar.com/floorball-t1/sv/tournaments/sr:tournament:255/results.json?api_key=xsbpbssr445356pmrrewsz5a"),
        //        Method = HttpMethod.Get
        //    };

        //    var response = await client.SendAsync(req);
        //    var data = await response.Content.ReadAsStringAsync();
        //    var parsedData = JsonConvert.DeserializeObject<SSLResult>(data).results;

        //    return parsedData;
        //}

        public async Task<IList<Result>> GetResults()
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.sportradar.com/floorball-t1/sv/tournaments/sr:tournament:255/results.json?api_key=xsbpbssr445356pmrrewsz5a"),
                Method = HttpMethod.Get
            };

            var response = await client.SendAsync(req);
            var data = await response.Content.ReadAsStringAsync();
            var parsedData = JsonConvert.DeserializeObject<SSLResult>(data).results;

            return parsedData;
        }
    }
}
