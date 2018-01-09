using System;
using System.Collections.Generic;

namespace Innebandy.Models
{
    public class Sport
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string country_code { get; set; }
    }

    public class CurrentSeason
    {
        public string id { get; set; }
        public string name { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string year { get; set; }
    }

    public class Tournament
    {
        public string id { get; set; }
        public string name { get; set; }
        public Sport sport { get; set; }
        public Category category { get; set; }
        public CurrentSeason current_season { get; set; }
    }

    public class Season
    {
        public string id { get; set; }
        public string name { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string year { get; set; }
        public string tournament_id { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class TeamStanding
    {
        public Team team { get; set; }
        public int rank { get; set; }
        public string current_outcome { get; set; }
        public int played { get; set; }
        public int win { get; set; }
        public int draw { get; set; }
        public int loss { get; set; }
        public int score_for { get; set; }
        public int score_against { get; set; }
        public int score_diff { get; set; }
        public int points { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<TeamStanding> team_standings { get; set; }
    }

    public class Standing
    {
        public string tie_break_rule { get; set; }
        public string type { get; set; }
        public IList<Group> groups { get; set; }
    }

    public class SSLStanding
    {
        public DateTime generated_at { get; set; }
        public string schema { get; set; }
        public Tournament tournament { get; set; }
        public Season season { get; set; }
        public IList<Standing> standings { get; set; }
    }



}
