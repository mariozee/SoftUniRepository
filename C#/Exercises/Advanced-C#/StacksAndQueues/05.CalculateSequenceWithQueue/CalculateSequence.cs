using System;
using System.Collections.Generic;

namespace _05.CalculateSequenceWithQueue
{
    class CalculateSequence
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> sequnce = new Queue<long>();
            List<long> numbers = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                numbers.Add(n);
                sequnce.Enqueue(n + 1);
                sequnce.Enqueue(2 * n + 1);
                sequnce.Enqueue(n + 2);

                n = sequnce.Dequeue();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}