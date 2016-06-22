using System;
using System.Linq;
using Lab_OOP_November_20.Models;

namespace Lab_OOP_November_20
{
    static class LeagueManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("AddTeam [team name] [team nickname] [date founded]");
            Console.WriteLine("AddMatch [team name] [team nickname] [date founded] [team name] [team nickname] [date found] [team 1 score] [team 2 score] [match id]");
            Console.WriteLine("AddPlayerToTeam [first name] [last name] [salary] [date of birth] [team name]");
            Console.WriteLine("ListMatches - Prints all matches");
            Console.WriteLine("ListTeams - Prints all teams");
            string line = Console.ReadLine();
            while (line != "End")
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                line = Console.ReadLine();
            }
        }

        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3], int.Parse(inputArgs[4]), int.Parse(inputArgs[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]), decimal.Parse(inputArgs[4]),
                        inputArgs[5]);
                    break;
                case "ListTeams":
                    PrintTeams();
                    break;
                case "ListMatches":
                    PrintMatches();
                    break;
            }
        }

        private static void AddTeam(string name, string nickname, DateTime dateFounded)
        {
            League.AddTeam(new Team(name, nickname, dateFounded));
            Console.WriteLine("Cuccessful added team: {0}", name);
        }

        private static void AddMatch(int id, string firstTeamName,
            string secondTeamName,
            int awayTeamGoals,
            int homeTeamGoals)
        {

            Score score = new Score(awayTeamGoals, homeTeamGoals);

            bool checkFirstTeam = League.Teams.Any(p => p.Name == firstTeamName);
            bool checkSecondTeam = League.Teams.Any(p => p.Name == secondTeamName);

            if (checkFirstTeam && checkSecondTeam)
            {
                Console.WriteLine("Successful added match: {0} vs {1}", firstTeamName, secondTeamName);
                Team teamOne = League.Teams.First(p => p.Name.Equals(firstTeamName));
                Team teamTwo = League.Teams.First(p => p.Name.Equals(secondTeamName));
                League.AddMatch(new Match(id, teamOne, teamTwo, score));
            }
            else
            {
                throw new ArgumentException("One of the teams or both doesn't exist");
            }
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime dateOfBirth, decimal salary,
            string name)
        {
            Player player = new Player(firstName, lastName, salary, dateOfBirth);
            Team team = League.Teams.First(t => t.Name.Equals(name));

            if (!League.Teams.Contains(team))
            {
                League.AddTeam(team);
            }

            team.AddPlayer(player);
            Console.WriteLine("Successful added player {0} {1} to team {2}", firstName, lastName, name);
        }

        private static void PrintTeams()
        {
            foreach (var team in League.Teams)
            {
                Console.WriteLine();
                Console.WriteLine(team.ToString());
            }
        }

        private static void PrintMatches()
        {
            foreach (var match in League.Matches)
            {
                Console.WriteLine();
                Console.WriteLine(match.ToString());
            }
        }
    }
}
