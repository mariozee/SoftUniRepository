using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());

            numbers = Reverse(numbers, (x, y) => x % y != 0, divider);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> Reverse(List<int> numbers, Func<int, int, bool> func, int divider)
        {
            List<int> newNumbers = new List<int>();
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (func(numbers[i], divider))
                {
                    newNumbers.Add(numbers[i]);
                }
            }

            return newNumbers;
        }
    }
}