namespace _03.Mankind.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: {value}");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            string output = String.Format("First Name: {0}{2}Last Name: {1}{2}"
                , this.FirstName, this.LastName, Environment.NewLine);

            return output;
        }
    }
}
