using Problem3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    using Enum;
    class Manager : Employee, IManager
    {
        public Manager(string firstName, string lastName, string id, 
            decimal salary, Department department, List<Employee> employees)
            : base (firstName, lastName, id, salary, department)
        {
            this.Employees = employees;
        }

        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            string output = "";
            output += base.ToString();

            foreach (var employee in this.Employees)
            {
                Console.WriteLine(employee);
            }

            return output;
        }
    }
}
