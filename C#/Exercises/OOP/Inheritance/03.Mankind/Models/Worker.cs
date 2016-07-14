namespace _03.Mankind.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker : Human
    {
        private const int WeeklyWorkingDays = 5;
        private const double MinWeeklySalary = 11;
        private const int MinWorkingHoursPerDay = 1;
        private const int MaxWorkingHoursPerDay = 12;

        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            HourlySalary = CalculateHourlySalary();
        }

        public double HourlySalary { get; protected set; }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            protected set
            {
                if (value < MinWeeklySalary)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            protected set
            {
                if (value < MinWorkingHoursPerDay || MaxWorkingHoursPerDay < value)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.workHoursPerDay = value;
            }
        }

        private double CalculateHourlySalary()
        {
            double result = this.WeekSalary / WeeklyWorkingDays;
            result /= workHoursPerDay;

            return result;
        }

        public override string ToString()
        {
            string output = string.Format("{0}Week Salary: {1:F2}{4}Hours per day: {2:F2}{4}Salary per hour: {3:F2}{4}"
                , base.ToString(), this.WeekSalary, this.WorkHoursPerDay, this.HourlySalary, Environment.NewLine);

            return output;
        }
    }
}