using Problem3;
using Problem3.Enum;
using Problem3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = new List<Person>()
            {
                new Manager("Bosio", "Shefov", "0000", 5000, Department.Accouintg, new List<Employee>()
                {
                    new Developer("Razbirach", "Tehnicharov", "234234", 3000, Department.Accouintg, new List<Project>()
                    {
                        new Project("Very Expesive Software", new DateTime(2014, 12, 9),
                        "Top secret project for a lot of moeney",
                        State.Open)
                    })
                })
            };        
          //  peoples.ForEach(Console.WriteLine);

            Project asd = new Project("AAAAA", new DateTime(1912, 12, 11),
                "sdksdojsdfo sojdvnsoj sonsdioc sndvns oisdoi s", State.Open);

            Console.WriteLine(asd);

            asd.CloseProject();

            Console.WriteLine(asd);
        }
    }
}
