using System;
using System.Collections.Generic;

namespace _06.AMinerTask
{
    class AMinerTask
    {
        static void Main()
        {
            Dictionary<string, long> resourceQuantity = new Dictionary<string, long>();

            string input;
            int counter = 1;
            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity.Add(resource, 0);
                }

                resourceQuantity[resource] += quantity;
            }

            foreach (var pair in resourceQuantity)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}