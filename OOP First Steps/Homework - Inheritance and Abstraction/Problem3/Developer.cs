using Problem3.Enum;

namespace Problem3
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class Developer : Employee, IDeveloper
    {
        public Developer(string firstName, string lastName, string id, 
            decimal salary, Department department, List<Project> projects)
            : base(firstName, lastName, id, salary, department)
        {
            this.Projects = projects;
        }

        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            string output = "";
            output += base.ToString();

            foreach (var project in this.Projects)
            {
                output += project;
            }

            return output;
        }
    }
}
