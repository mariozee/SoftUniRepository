using System;
using System.Collections.Generic;

namespace _14.DragonArmy
{
    class DragonArmy
    {
        private const int HealthDefault = 250;
        private const int DamageDefault = 45;
        private const int ArmorDefault = 10;

        static Dictionary<string, SortedDictionary<string, int[]>> dragonsData;
        static Dictionary<string, double[]> dragonsTypeStats;

        static void Main(string[] args)
        {
            dragonsData = new Dictionary<string, SortedDictionary<string, int[]>>();

            dragonsTypeStats = new Dictionary<string, double[]>();

            int n = int.Parse(Console.ReadLine());

            InitializeData(n);

            CalculateAvarageStats();

            PrintResult();
        }

        private static void InitializeData(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');

                string type = inputArgs[0];
                string name = inputArgs[1];
                int damage = inputArgs[2] == "null" ? DamageDefault : int.Parse(inputArgs[2]);
                int health = inputArgs[3] == "null" ? HealthDefault : int.Parse(inputArgs[3]);
                int armor = inputArgs[4] == "null" ? ArmorDefault : int.Parse(inputArgs[4]);

                if (!dragonsData.ContainsKey(type))
                {
                    dragonsData.Add(type, new SortedDictionary<string, int[]>());
                    dragonsTypeStats.Add(type, new double[3]);
                }

                if (!dragonsData[type].ContainsKey(name))
                {
                    dragonsData[type].Add(name, new int[3]);
                }

                dragonsData[type][name] = new int[] { damage, health, armor };
            }
        }        

        private static void CalculateAvarageStats()
        {
            foreach (var type in dragonsData.Keys)
            {
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;
                foreach (var dragon in dragonsData[type])
                {
                    avgDamage += dragon.Value[0];
                    avgHealth += dragon.Value[1];
                    avgArmor += dragon.Value[2];
                }

                int dragonsCount = dragonsData[type].Count;
                avgDamage /= dragonsCount;
                avgHealth /= dragonsCount;
                avgArmor /= dragonsCount;

                dragonsTypeStats[type] = new double[] { avgDamage, avgHealth, avgArmor };
            }
        }

        private static void PrintResult()
        {
            foreach (var type in dragonsData.Keys)
            {
                Console.WriteLine(string.Format("{0}::({1:F2}/{2:F2}/{3:F2})",
                    type, dragonsTypeStats[type][0], dragonsTypeStats[type][1], dragonsTypeStats[type][2]));

                foreach (var dragon in dragonsData[type])
                {
                    Console.WriteLine(string.Format("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        dragon.Key, dragon.Value[0], dragon.Value[1], dragon.Value[2]));
                }
            }
        }
    }
}