using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main()
        {
            // 77 point out of 100
            // It's under construction.
            string n = Console.ReadLine();
            int deadPlants = -1;
            int day = 0;
            List<int> allPlants = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            while (deadPlants != 0)
            {
                day++;
                int plantsCount = allPlants.Count;

                for (int i = allPlants.Count - 1; i >= 1; i--)
                {
                    if (allPlants[i] > (allPlants[i - 1]))
                    {
                        allPlants.RemoveAt(i);
                    }
                }

                deadPlants = plantsCount - allPlants.Count;
            }

            Console.WriteLine(day - 1);
        }
    }
}