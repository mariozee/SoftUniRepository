using System;

namespace _02.NestedLoopsToRecursion
{
    class NestedLoopsToRecursion
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Loop(arr, n, 0);
        }

        private static void Loop(int[] arr, int n, int index)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i <= n; i++)
            {
                arr[index] = i;
                Loop(arr, n, index + 1);
            }
        }
    }
}
