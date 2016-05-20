using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int petrolPumpsCountDefault = int.Parse(Console.ReadLine());
            int n = petrolPumpsCountDefault;

            int tank = 0;

            Queue<List<int>> petrolPumps = new Queue<List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<int> currentPump = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                currentPump.Add(i);

                petrolPumps.Enqueue(currentPump);
            }

            while (true)
            {
                List<int> currnetPump = petrolPumps.Dequeue();
                petrolPumps.Enqueue(currnetPump);

                if ((currnetPump[0] + tank) - currnetPump[1] >= 0)
                {
                    n--;
                    tank += currnetPump[0];
                    tank -= currnetPump[1];
                }
                else
                {
                    n = petrolPumpsCountDefault;
                    tank = 0;
                }

                if (n == 0)
                {petrolPumps.Enqueue(currnetPump);

                    currnetPump = petrolPumps.Dequeue();
                    Console.WriteLine(currnetPump[2]);
                    break;
                }                
            }
        }
    }
}