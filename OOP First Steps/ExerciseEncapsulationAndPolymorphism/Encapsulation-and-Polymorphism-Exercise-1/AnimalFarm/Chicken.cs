using System;

namespace AnimalFarm
{
    class Chicken : Animal
    {
        private const int ChickenMaxAge = 7;

        public Chicken(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get
            {
                return base.Age;
            }
            protected set
            {
                if (value > ChickenMaxAge)
                {
                    throw new ArgumentOutOfRangeException("Checken age", "Age cannot be more than 7");
                }
                base.Age = value;
            }
        }

        public override Product ProduceProduct()
        {
            return new Product();
        }

        public override double GetHumanAge()
        {
            return this.Age * 11;
        }
    }
}
