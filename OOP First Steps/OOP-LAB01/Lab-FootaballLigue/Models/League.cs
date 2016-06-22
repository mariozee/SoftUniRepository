using System;
using System.Collections.Generic;
using System.Linq;

public static class League
{
    private static List<Teams> teams = new List<Teams>();
    private static List<Matches> matches = new List<Matches>();

    public static IEnumerable<Teams> Team
    {
        get { return teams; }
    }

    public static IEnumerable<Matches> Match
    {
        get { return matches; }
    }

    public static void AddTeam(Teams team)
    {
        if (IsTeamExist(team))
        {
            throw new InvalidOperationException("This team alredy exist!");
        }
        else
        {
            Console.WriteLine("Team added!");
            teams.Add(team);
        }

        
    }

    private static bool IsTeamExist(Teams team)
    {
        return teams.Any(t => t.Name == team.Name);
    }


    public static void AddMatch(Matches match)
    {
        if (IsMatchExist(match))
        {
            throw new InvalidOperationException("Their is Match with that ID!");
        }
        else
        {
            Console.WriteLine("Match added!");
            matches.Add(match);
        }
    }

    private static bool IsMatchExist(Matches match)
    {
        return matches.Any(m => m.Id == match.Id);
    }


    //LEAGUE MANAGER:


   

    public static void HandleInput(string input)
    {
        string[] inputArgs = input.Split();
        switch (inputArgs[0])
        {
            case "AddTeam":
                AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3])); break;
            case "AddMatch":
                AddMatch(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                    int.Parse(inputArgs[4]), int.Parse(inputArgs[5])); break;
            case "AddPlayerToTeam":
                AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]),
                    decimal.Parse(inputArgs[4]), inputArgs[4]); break;
            case "ListTeams":
                PrintTeams();
                break;
            case "ListMatches":
                PrintMatches();
                break;
        }

    }

    public static void AddTeam(string name, string nickName, DateTime dateFound)
    {
        AddTeam(new Teams(name, nickName, dateFound));
    }

    public static void AddMatch(int id, string firstTeam, string secondTeam, 
        int homeTeamGoals, int awayTeamGoals)
    {
        Score score = new Score(homeTeamGoals, awayTeamGoals);

        bool checkFirstTeam = Team.Any(t => t.Name == firstTeam);
        bool checkSecondTeam = Team.Any(t => t.Name == secondTeam);

        if (checkFirstTeam && checkSecondTeam)
        {
            Console.WriteLine("Match added: {0} vs {1}", firstTeam, secondTeam);
            Teams teamOne = Team.First(t => t.Name.Equals(firstTeam));
            Teams teamTwo = Team.First(t => t.Name.Equals(secondTeam));
            AddMatch(new Matches(teamOne, teamTwo, score, id));
        }
        else
        {
            throw new InvalidOperationException("Some of the teams do not exist.");
        }
    }

    public static void AddPlayerToTeam(string firstName, string lastName, DateTime birthDate, 
        decimal salary, string name)
    {
        Players player = new Players(firstName, lastName, salary, birthDate);
        Teams team = Team.First(t => t.Name.Equals(name));

        if (!Team.Contains(team))
        {
            AddTeam(team);
        }

        team.AddPlayer(player);
        Console.WriteLine("Player added: {0} {1} to team {2}", firstName, lastName, name);
    }

    private static void PrintTeams()
    {
        foreach (var team in Team)
        {
            Console.WriteLine();
            Console.WriteLine(team.ToString());
        }
    }

    private static void PrintMatches()
    {
        foreach (var match in Match)
        {
            Console.WriteLine();
            Console.WriteLine(match.ToString());
        }
    }
}

