using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{

    public static class ArithmeticExtention
    {
        public static List<int> ApplyFunc(this List<int> numbers, Func<int, int> func)
        {
            List<int> newNumbers = new List<int>();
            foreach (var num in numbers)
            {
                newNumbers.Add(func(num));
            }

            return newNumbers;
        }
    }

    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string commnad;
            while ((commnad = Console.ReadLine()) != "end")
            {
                if (commnad == "add")
                {
                    numbers = numbers.ApplyFunc(x => x + 1);
                }
                else if (commnad == "subtract")
                {
                    numbers = numbers.ApplyFunc(x => x - 1);
                }
                else if (commnad == "multiply")
                {
                    numbers = numbers.ApplyFunc(x => x * 2);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }         
    }
}