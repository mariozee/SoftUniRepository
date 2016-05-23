using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibN = new Stack<long>();
            fibN.Push(1);
            fibN.Push(1);

            for (int i = 0; i < n - 2; i++)
            {
                long newVal = fibN.Pop() + fibN.Peek();
                long oldVal = fibN.Pop();
                fibN.Push(newVal);
                fibN.Push(oldVal);
            }

            fibN.Pop();
            Console.WriteLine(fibN.Peek());
        }
    }
}
