using Problem3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem3.Enum;

namespace Problem3
{
    class Project : IProject
    {
        private string name;

        public Project(string name, DateTime start, string details, State state)
        {
            this.Name = name;
            this.Start = start;
            this.Details = details;
            this.State = state;
        }

        public string Details { get; set; }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Project name", "Name cannot be empty");
                }
                this.name = value;
            }
        }

        public DateTime Start { get; set; }

        public State State { get; set; }

        public void CloseProject()
        {
            this.State = State.Closed;
        }

        public override string ToString()
        {
            return string.Format("{4}Project name: {0} - State: {1}{4}Details:{4}{2}{4}Start date: {3}{4}",
                this.Name, this.State, this.Details, this.Start, Environment.NewLine);
        }
    }
}
