using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] operationsValues = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = operationsValues[0];
            int elementsToPop = operationsValues[1];
            int elementToFind = operationsValues[2];

            int[] numbersInput = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(elementsToPush);

            foreach (var number in numbersInput)
            {
                numbers.Push(number);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Contains(elementToFind) ? "true" : numbers.Min().ToString());
            }
            else
            {
                Console.WriteLine(0);
            }            
        }
    }
}