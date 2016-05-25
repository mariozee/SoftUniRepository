using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegedaryFarming
{
    class LegedaryFarming
    {
        static void Main()
        {
            Dictionary<string, string> legendaryItemsMap = new Dictionary<string, string>()
            {
                { "shards", "Shadowmourne" },
                { "fragments", "Valanyr" },
                { "motes", "Dragonwrath"}
            };

            SortedDictionary<string, int> keyMaterialsCount = new SortedDictionary<string, int>()
            {
                { "fragments", 0 },
                { "motes", 0 },
                { "shards", 0 }
            };

            SortedDictionary<string, int> junkIntemsCount = new SortedDictionary<string, int>();

            bool isLegendaryItemFound = false;

            while (!isLegendaryItemFound)
            {
                string[] inputArgs = Console.ReadLine().ToLower().Split(' ');
                for (int i = 0; i < inputArgs.Length - 1; i+=2)
                {
                    int qunatity = int.Parse(inputArgs[i]);
                    string material = inputArgs[i + 1];

                    if (keyMaterialsCount.ContainsKey(material))
                    {
                        keyMaterialsCount[material] += qunatity;
                        if (keyMaterialsCount[material] >= 250)
                        {
                            keyMaterialsCount[material] -= 250;
                            isLegendaryItemFound = true;
                            Console.WriteLine(legendaryItemsMap[material] + " obtained!");
                            break;
                        }
                    }
                    else
                    {
                        if (!junkIntemsCount.ContainsKey(material))
                        {
                            junkIntemsCount.Add(material, 0);
                        }

                        junkIntemsCount[material] += qunatity;
                    }
                }
            }

            var sortedKeyMaterials = keyMaterialsCount.OrderByDescending(x => x.Value);

            foreach (var pair in sortedKeyMaterials)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var pair in junkIntemsCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}