namespace _03.Mankind.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Student : Human
    {
        private const int MinFacultyNumberLenght = 5;
        private const int MaxFacultyNumberLenght = 10;
        private string facultyNumberValidationPattern = $@"^[A-Za-z0-9]{"{"}{MinFacultyNumberLenght},{MaxFacultyNumberLenght}{"}"}$";
        
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public override string FirstName
        {
            get
            {
                return base.FirstName;
            }

            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {value}");
                }

                base.FirstName = value;
            }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            protected set
            {
                Match match = Regex.Match(value, facultyNumberValidationPattern);
                if (!match.Success)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format("{0}Faculty number: {1}{2}"
                , base.ToString(), this.FacultyNumber, Environment.NewLine);

            return output;
        }
    }
}