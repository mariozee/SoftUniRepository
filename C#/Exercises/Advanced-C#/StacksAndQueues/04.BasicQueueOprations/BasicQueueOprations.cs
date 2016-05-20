using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOprations
{
    class BasicQueueOprations
    {
        static void Main()
        {
            int[] operationsArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbersInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int enqueuesCount = operationsArgs[0];
            int dequeuesCount = operationsArgs[1];
            int numberToCheck = operationsArgs[2];

            Queue<int> numbers = new Queue<int>(enqueuesCount);

            for (int i = 0; i < enqueuesCount; i++)
            {
                numbers.Enqueue(numbersInput[i]);
            }

            for (int i = 0; i < dequeuesCount; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Contains(numberToCheck) ? "true" : numbers.Min().ToString());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
