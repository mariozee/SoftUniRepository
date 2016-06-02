using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class RecursiveArraySum
    {
        static void Main()
        {
            Console.WriteLine("Type several integer numbers separated by single space:");
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = FindSum(array, 0);
        }

        private static int FindSum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + FindSum(array, index + 1);
        }
    }
}