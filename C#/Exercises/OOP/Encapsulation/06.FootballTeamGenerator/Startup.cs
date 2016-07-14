namespace _06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static List<Team> teams = new List<Team>();

        static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                try
                {
                    string[] inputArgs = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (inputArgs[0] == "Team")
                    {
                        Team team = CreateTeam(inputArgs[1]);
                        teams.Add(team);
                    }
                    else if (inputArgs[0] == "Add")
                    {
                        AddPlayerToTeam(inputArgs);
                    }
                    else if (inputArgs[0] == "Remove")
                    {
                        RemovePlayerFromTeam(inputArgs[1], inputArgs[2]);
                    }
                    else if (inputArgs[0] == "Rating")
                    {
                        PrintTeamRating(inputArgs[1]);
                    }
                }
                catch (ArgumentException e)
                {                    
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    line = Console.ReadLine();
                }
            }
        }

        private static void PrintTeamRating(string teamName)
        {
            var team = teams.Where(t => t.Name == teamName).FirstOrDefault();
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            double rating = Math.Round(team.GetTeamRating());
            Console.WriteLine($"{teamName} - {rating}");
        }

        private static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            var team = teams.Where(t => t.Name == teamName).FirstOrDefault();
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            team.RemovePlayer(playerName);
        }

        private static void AddPlayerToTeam(string[] inputArgs)
        {
            string teamName = inputArgs[1];

            var team = teams.Where(t => t.Name == teamName).FirstOrDefault();
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            string playerName = inputArgs[2];
            double stat1 = double.Parse(inputArgs[3]);
            double stat2 = double.Parse(inputArgs[4]);
            double stat3 = double.Parse(inputArgs[5]);
            double stat4 = double.Parse(inputArgs[6]);
            double stat5 = double.Parse(inputArgs[7]);

            var player = new Player(playerName, stat1, stat2, stat3, stat4, stat5);
            team.AddPlayer(player);
        }

        private static Team CreateTeam(string teamName)
        {
            Team team = new Team(teamName);

            return team;
        }
    }
}
