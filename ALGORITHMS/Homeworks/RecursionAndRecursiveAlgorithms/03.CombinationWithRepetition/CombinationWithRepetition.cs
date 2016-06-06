using System;

namespace _03.CombinationWithRepetition
{
    class CombinationWithRepetition
    {
        static int[] arr;
        static int k;
        static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            arr = new int[k];

            GenerateCombinations(0, 1);
        }

        private static void GenerateCombinations(int index, int startIndex)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int num = startIndex; num <= n; num++)
            {
                arr[index] = num;
                GenerateCombinations(index + 1, num);
            }
        }
    }
}