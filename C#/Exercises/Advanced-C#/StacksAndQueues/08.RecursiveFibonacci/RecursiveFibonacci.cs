using System;

namespace _08.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //Measure executing time by uncomment the three lines below.
            //DateTime start = DateTime.Now;
            long fibN = Fibonacci(n);
            //DateTime end = DateTime.Now;
            Console.WriteLine(fibN);
            //Console.WriteLine(end - start);
        }

        static long Fibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
