
namespace Problem2
{
    using System;

    public enum Gender
    {
        Male,
        Female
    }

    public abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
