using System;

namespace Lab_OOP_November_20.Models
{
    public class Score
    {
        private int homeTeamGoals;
        private int awayTeamGoals;

        public Score(int awayTeamGoals, int homeTeamGoals)
        {
            this.AwayTeamGoals = awayTeamGoals;
            this.HomeTeamGoals = homeTeamGoals;
        }

        public int HomeTeamGoals
        {
            get
            {
                return this.homeTeamGoals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Goals cannot be negative");
                }
                this.homeTeamGoals = value;
            }
        }

        public int AwayTeamGoals
        {
            get
            {
                return this.awayTeamGoals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Goals cannot be negative");
                }
                this.awayTeamGoals = value;
            }
        }
    }
}
