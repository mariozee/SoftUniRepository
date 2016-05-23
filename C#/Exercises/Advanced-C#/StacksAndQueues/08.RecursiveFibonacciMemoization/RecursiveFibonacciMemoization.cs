using System;

namespace _08.RecursiveFibonacciMemoization
{
    class RecursiveFibonacciMemoization
    {
        static long[] fibNumbers;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            fibNumbers = new long[n + 2];
            fibNumbers[1] = 1;
            fibNumbers[2] = 1;

            //Measure executing time by uncomment the three lines below.
            //DateTime start = DateTime.Now;
            long fibN = Fibonacci(n);
            //DateTime end = DateTime.Now;
            Console.WriteLine(fibN);
            //Console.WriteLine(end - start);

        }

        private static long Fibonacci(int n)
        {
            if (fibNumbers[n] == 0)
            {
                fibNumbers[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            return fibNumbers[n];
        }
    }
}