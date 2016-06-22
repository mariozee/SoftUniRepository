using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPayDay = workHoursPerDay;
        }

        public int WeekSalary { get; set; }

        public int WorkHoursPayDay { get; set; }

        public double MoneyPerHour(int salary, int hoursPerWeek)
        {
            return salary / hoursPerWeek;
        }
    }
}
