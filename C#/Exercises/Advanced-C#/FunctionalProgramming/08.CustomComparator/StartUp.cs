using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cc = new CustomComparator();
            Array.Sort(array, cc);

            Console.WriteLine(string.Join(" ", array));
        }
    }

    public class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                return x.CompareTo(y);
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
}