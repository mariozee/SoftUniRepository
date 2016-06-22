using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_OOP_November_20.Models
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddMatch(Match match)
        {
            if (CheckMatchExists(match))
            {
                throw new InvalidOperationException("This match already exists");
            }
            matches.Add(match);
        }

        public static void AddTeam(Team team)
        {
            if (CheckTeamExists(team))
            {
                throw new InvalidOperationException("This team already exists");
            }
            teams.Add(team);
        }

        public static bool CheckMatchExists(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }

        public static bool CheckTeamExists(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }
    }
}
