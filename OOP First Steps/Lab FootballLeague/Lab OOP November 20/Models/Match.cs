using System;
using System.Collections.Generic;

namespace Lab_OOP_November_20.Models
{
    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        public Match(int id, Team homeTeam, Team awayTeam, Score score)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.Id = id;
        }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public Score Score { get; set; }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The ID should be a positive number");
                }
                this.id = value;
            }
        }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.AwayTeamGoals > this.Score.HomeTeamGoals
                ? this.AwayTeam
                : this.HomeTeam;
        }

        public bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

        public override string ToString()
        {
            List<string> output = new List<string>();

            string winner = "";
            if (IsDraw())
            {
                winner = "Draw";
            }
            else
            {
                winner = GetWinner().Name;
            }

            output.Add(String.Format("[HomeTeam] - [AwayTeam]: Score\n{0} - {1}: {2} - {3}\n(Winner: {4})", 
                this.HomeTeam.Name, 
                this.AwayTeam.Name, 
                this.Score.HomeTeamGoals,
                this.Score.AwayTeamGoals,
                winner));

            return String.Join("", output);
        }
    }
}
