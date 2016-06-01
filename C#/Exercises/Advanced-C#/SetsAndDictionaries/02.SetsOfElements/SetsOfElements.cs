using System;
using System.Collections.Generic;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main()
        {
            string[] setsLenght = Console.ReadLine().Split(' ');
            int n = int.Parse(setsLenght[0]);
            int m = int.Parse(setsLenght[1]);

            HashSet<string> nSet = new HashSet<string>();
            HashSet<string> mSet = new HashSet<string>();

            for (int i = 0; i < n + m; i++)
            {
                if (i < n)
                {
                    nSet.Add(Console.ReadLine());
                }
                else
                {
                    mSet.Add(Console.ReadLine());
                }
            }

            nSet.IntersectWith(mSet);

            Console.WriteLine(string.Join(" ", nSet));
        }
    }
}