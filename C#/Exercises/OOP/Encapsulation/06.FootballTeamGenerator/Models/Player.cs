namespace _06.FootballTeamGenerator.Models
{
    using System;

    public class Player
    {
        private const double MinStatValue = 0;
        private const double MaxStatValue = 100;

        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.Overall = CalculateOverallStats();
        }

        public double Overall { get; private set; }

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

        public double Endurance
        {
            get { return this.endurance; }
            set
            {
                if (ValidateStats(value))
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public double Sprint
        {
            get { return this.sprint; }
            set
            {
                if (ValidateStats(value))
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public double Dribble
        {
            get { return this.dribble; }
            set
            {
                if (ValidateStats(value))
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public double Passing
        {
            get { return this.passing; }
            set
            {
                if (ValidateStats(value))
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public double Shooting
        {
            get { return this.shooting; }
            set
            {
                if (ValidateStats(value))
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        private bool ValidateStats(double stat)
        {
            bool result = false;
            if (stat < MinStatValue || MaxStatValue < stat)
            {
                result = true;
            }

            return result;
        }

        private double CalculateOverallStats()
        {
            double overall = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5;

            return overall;
        }
    }
}
