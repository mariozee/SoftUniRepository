namespace Problem3
{
    using Interfaces;
    using System;
    using Enum;

    public class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(string firstName, string lastName, string id, decimal salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public Department Department
        {
            get
            {
                return this.department;
            }
            set { this.department = value; }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary cant be negative number");
                }
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{2}Salary: {0}{2}Department: {1}{2}",
                this.Salary, this.Department, Environment.NewLine);
        }
    }
}
