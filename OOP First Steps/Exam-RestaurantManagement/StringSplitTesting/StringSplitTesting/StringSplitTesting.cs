using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSplitTesting
{
    class StringSplitTesting
    {
        static void Main()
        {
            string testString = "CreateRestaurant(name=New Restaurant;location=Sofia)";
            string[] testStringArgs = testString.Split('(', ')', ';', '=');

            switch (testStringArgs[0])
            {
                case "CreateRestaurant":
                    CreateRestaurante(testStringArgs);
                    break;
                default:
                    break;
            }
        }

        private static void CreateRestaurante(string[] testStringArgs)
        {
            int indexOfName = testStringArgs.ToList().IndexOf("name");
            int indexOfLocation = testStringArgs.ToList().IndexOf("location");
            string restaurantName = testStringArgs[indexOfName + 1];
            string restaurantLocation = testStringArgs[indexOfLocation + 1];
            Console.WriteLine(restaurantName + " " + restaurantLocation);
        }
    }
}
