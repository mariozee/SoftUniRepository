using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class MaximumElement
    {
        static void Main()
        {
            int iterations = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            int maxValue = Int32.MinValue;

            for (int i = 0; i < iterations; i++)
            {
                string operation = Console.ReadLine();

                if (operation[0] == '1')
                {
                    int number = int.Parse(operation.Split(' ')[1]);
                    numbers.Push(number);

                    if (number > maxValue)
                    {
                        maxValue = number;
                    }                    
                }
                else if (operation[0] == '2')
                {
                    if (numbers.Count > 0)
                    {
                        if (numbers.Pop() == maxValue)
                        {
                            maxValue = numbers.Count > 0 ? numbers.Max() : 0;
                        }
                    }
                }
                else if (operation[0] == '3')
                {
                    Console.WriteLine(numbers.Count > 0 ? maxValue : 0);
                }
            }
        }
    }
}