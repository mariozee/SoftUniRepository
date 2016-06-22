using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        class Dog
        {
            public Dog(string name, int age = 0)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }
        

        static void Main(string[] args)
        {
            Dog d = new Dog("Rex");
            Console.WriteLine(d.Age);
        }
    }
}
