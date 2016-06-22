using System;

namespace Lab_OOP_November_20.Models
{
    public class Player
    {
        private const int MinimalAllowedYear = 1980;

        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime dateOfBirth;
        private Team team;

        public Player(string firstName, string lastName, decimal salary, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("Names of the player should be at least 3 characters long.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("Names of the player should be at least 3 characters long.");
                }
                this.lastName = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                this.salary = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value.Year < MinimalAllowedYear)
                {
                    throw new ArgumentOutOfRangeException("Year of birth cannot be lower than " + MinimalAllowedYear);
                }
                this.dateOfBirth = value;
            }
        }

        public Team Team { get; set; }
    }
}
