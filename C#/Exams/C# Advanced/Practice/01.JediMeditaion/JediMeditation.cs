using System;
using System.Collections.Generic;

namespace _01.JediMeditaion
{
    class JediMeditation
    {
        static void Main(string[] args)
        {
            List<string> knights = new List<string>();
            List<string> masters = new List<string>();
            List<string> padalans = new List<string>();
            List<string> toshkoAndSlav = new List<string>();
            bool isMasterCame = false;

            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string input = Console.ReadLine();
                string[] jedis = input.Split();
                foreach (var jedi in jedis)
                {
                    if (jedi.StartsWith("y"))
                    {
                        isMasterCame = true;
                    }
                    else if (jedi.StartsWith("m"))
                    {
                        masters.Add(jedi);
                    }
                    else if (jedi.StartsWith("k"))
                    {
                        knights.Add(jedi);
                    }
                    else if (jedi.StartsWith("p"))
                    {
                        padalans.Add(jedi);
                    }
                    else
                    {
                        toshkoAndSlav.Add(jedi);
                    }
                }
            }

            if (isMasterCame)
            {
                Console.WriteLine($"{string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", toshkoAndSlav)} {string.Join(" ", padalans)}");
            }
            else
            {
                Console.WriteLine($"{string.Join(" ", toshkoAndSlav)} {string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", padalans)}");
            }
        }
    }
}