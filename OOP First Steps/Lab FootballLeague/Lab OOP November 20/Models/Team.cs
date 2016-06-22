using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_OOP_November_20.Models
{
    public class Team
    {
        private static int MinimumYearAllowed = 1850;

        private string name;
        private string nickname;
        private DateTime dateFound;
        private List<Player> players;

        public Team(string name, string nickname, DateTime dateFound)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.DateFound = dateFound;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Trim().Length < 5)
                {
                    throw new IndexOutOfRangeException("Team name must contain at least 5 characters.");
                }
                this.name = value;
            }
        }

        public string Nickname
        {
            get
            {
                return this.nickname;
            }

            set
            {
                if (value.Trim().Length < 5)
                {
                    throw new IndexOutOfRangeException("Team nickname must contain at least 5 characters.");
                }
                this.nickname = value;
            }
        }

        public DateTime DateFound
        {
            get
            {
                return this.dateFound;
            }
            set
            {
                if (value.Year < MinimumYearAllowed)
                {
                    throw new ArgumentOutOfRangeException("Date found should be grather than " + MinimumYearAllowed);
                }
                this.dateFound = value;
            }
        }

        public IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        public void AddPlayer(Player player)
        {
            if (CheckPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exists for that team");
            }
            this.players.Add(player);
            player.Team = this;
        }

        private bool CheckPlayerExists(Player player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName &&
                p.LastName == player.LastName);
        }

        public override string ToString()
        {
            List<String> output = new List<string>();

            output.Add(String.Format("Name: {0}{1}", this.Name, Environment.NewLine));
            output.Add(String.Format("Nickname: {0}{1}", this.Nickname, Environment.NewLine));
            output.Add(String.Format("Date found: {0}", this.DateFound, Environment.NewLine));
            if (this.Players.Count() > 0)
            {
                output.Add(String.Format("{0}Players:", Environment.NewLine));
                foreach (var player in this.Players)
                {
                    output.Add(String.Format("{4}[{3}]{0} {1} - {2} BGN", player.FirstName, player.LastName, player.Salary, player.DateOfBirth, Environment.NewLine));
                }
            }

            return String.Join("", output);
        }
    }
}
