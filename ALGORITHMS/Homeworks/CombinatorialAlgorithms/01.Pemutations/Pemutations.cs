using System;
using System.Linq;

namespace _01.Pemutations
{
    class Pemutations
    {
        static int n;
        static int[] array;

        static int permutationsCount = 0;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            var start = DateTime.Now;
            array = Enumerable.Range(1, n).ToArray();

            GeneratePermutations(0);
            Console.WriteLine("Total permutations: " + permutationsCount);
            var end = DateTime.Now;
            Console.WriteLine(end - start);
        }

        private static void GeneratePermutations(int startIndex)
        {
            if (startIndex >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                permutationsCount++;
            }
            else
            {
                for (int i = startIndex; i < n; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    GeneratePermutations(startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }

        }

        private static void Swap(ref int v1, ref int v2)
        {
            if (v1 == v2)
            {
                return;
            }

            v1 ^= v2;
            v2 ^= v1;
            v1 ^= v2;
        }
    }
}
