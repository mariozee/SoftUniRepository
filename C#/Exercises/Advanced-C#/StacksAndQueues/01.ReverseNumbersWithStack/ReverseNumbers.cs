using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ReverseNumbersWithStack
{
    class ReverseNumbers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (int number in numbers)
            {
                stack.Push(number);
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
