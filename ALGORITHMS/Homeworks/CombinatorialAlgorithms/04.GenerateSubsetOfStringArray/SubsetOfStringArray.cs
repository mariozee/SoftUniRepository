using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GenerateSubsetOfStringArray
{
    class SubsetOfStringArray
    {
        static string[] arr;
        static int[] indexes;
        static int n;
        static int k;

        static void Main()
        {
            arr = Console.ReadLine().Split(' ');
            k = int.Parse(Console.ReadLine());
            n = arr.Length;
            indexes = new int[k];

            GeneerateVariations(0, 0);
        }

        private static void GeneerateVariations(int index, int start)
        {
            if (index == k)
            {
                Print();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    indexes[index] = i;
                    GeneerateVariations(index + 1, i + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine($"({string.Join(" ", indexes.Select(i => arr[i]))})");
        }
    }
}
