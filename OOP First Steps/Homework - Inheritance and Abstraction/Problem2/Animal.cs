using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public abstract class Animal : ISoundProducible
    {
        private int age;
        private string gender;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative");
                }
                this.age = value;
            }
        }

        private Gender Gender { get; set; }
      
        public abstract void ProduceSound();
    }
}
