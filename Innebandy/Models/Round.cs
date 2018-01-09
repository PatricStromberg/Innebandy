using System;
namespace Innebandy.Models
{
    public class Round
    {
        public string home_team_name { get; set; }
        public string away_team_name { get; set; }
        public int home_team_score { get; set; }
        public int away_team_score { get; set; }
        public string home_team_exclusion { get; set; }
        public string away_team_exclusion { get; set; }
        public int number { get; set; }
    }
}
