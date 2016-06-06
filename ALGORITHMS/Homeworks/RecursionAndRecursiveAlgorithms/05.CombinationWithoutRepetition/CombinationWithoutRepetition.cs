using System;

namespace _05.CombinationWithoutRepetition
{
    class CombinationWithoutRepetition
    {
        static int n;
        static int k;
        static int[] arr;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            arr = new int[k];

            Combo(1, 0);
        }

        private static void Combo(int startNum, int index)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int num = startNum; num <= n; num++)
                {
                    arr[index] = num;
                    Combo(num + 1, index + 1);
                }
            }
        }
    }
}