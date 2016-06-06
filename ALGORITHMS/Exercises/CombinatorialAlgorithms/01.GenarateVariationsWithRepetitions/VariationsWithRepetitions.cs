using System;

namespace _01.GenarateVariationsWithRepetitions
{
    class VariationsWithRepetitions
    {
        static int[] array;
        static int n;
        static int k;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[k];

            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index == k)
            {
                Print();
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    array[index] = i;
                    GenerateVariations(index + 1);
                }
            }               
        }

        private static void Print()
        {
            Console.WriteLine("(" + string.Join(",", array) + ")");
        }
    }
}
