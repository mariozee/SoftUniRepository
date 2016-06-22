using System;
using System.Collections.Generic;
using System.Linq;

public class Teams
{
    private const int minimumAllowedYear = 1850;

    private string name;
    private string nickName;
    private DateTime dateFounding;
    private List<Players> players;

    public Teams(string name, string nickName, DateTime dateFounding)
    {
        this.Name = name;
        this.NickName = nickName;
        this.DateFounding = dateFounding;
        this.players = new List<Players>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Trim().Length < 5)
            {
                throw new ArgumentException("Team name must be atleast 5 charcters!");
            }
            this.name = value;
        }
    }

    public string NickName
    {
        get { return this.nickName; }
        set
        {
            if (value.Trim().Length < 5)
            {
                throw new ArgumentException("Nick name must be atleast 5 charcters!");
            }
            this.nickName = value; 
        }
    }

    public DateTime DateFounding
    {
        get { return this.dateFounding; }
        set
        {
            if (value.Year < minimumAllowedYear)
            {
                throw new ArgumentException("Date founding cant be before 1850");
            }
            this.dateFounding = value;
        }
    }

    public IEnumerable<Players> PLayers
    {
        get { return this.players; }
    }

    public void AddPlayer(Players player)
    {
        if (CheckIfPlayerExist(player))
        {
            throw new InvalidOperationException("Player already exist for that team!");
        }

        this.players.Add(player);
    }

    private bool CheckIfPlayerExist(Players player)
    {
        return this.players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
    }

    public override string ToString()
    {
        List<string> output = new List<string>();
        output.Add(string.Format("Name: {0}{1}", this.Name, Environment.NewLine));
        output.Add(string.Format("Nick name: {0}{1}", this.NickName, Environment.NewLine));
        output.Add(string.Format("Date Founded: {0}{1}", this.DateFounding, Environment.NewLine));
        Console.WriteLine("Players: ");
        Console.WriteLine();

        foreach (var player in this.PLayers)
        {
            output.Add(string.Format("Name: {0} {1}", player.FirstName, player.LastName));
            output.Add(string.Format("Sallary: {0}{1}", player.Salary, Environment.NewLine));
            output.Add(string.Format("Date of birth: {0}{1}", player.DateIfBirth, Environment.NewLine));
            Console.WriteLine();
        }

        return string.Join("", output);
    }
}

