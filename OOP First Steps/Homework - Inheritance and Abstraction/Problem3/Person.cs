namespace Problem3
{
    using System;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string id;
        private string lastName;

        public Person(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("firstName", "Name cannot be empty");
                }
                this.firstName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("id", "ID cannot be empty");
                }
                this.id = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be empty");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("First Name: {0}{3}Last Name: {1}{3}ID: {2}",
                this.FirstName, this.LastName, this.Id, Environment.NewLine);
        }
    }
}

