namespace _06.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.Where(p => p.Name == playerName).FirstOrDefault();

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            else
            {
                players.Remove(player);
            }
        }

        public double GetTeamRating()
        {
            double rating = 0;
            if (players.Count == 0)
            {
                return rating;
            }
            else
            {
                foreach (var player in players)
                {
                    rating += player.Overall;
                }

                rating /= players.Count;

                return rating;
            }            
        }
    }
}