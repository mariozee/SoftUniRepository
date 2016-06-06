using System;

namespace _02.GenarateVariationsWithoutRepetions
{
    class VariationsWithoutRepetions
    {
        static int[] array;
        static int[] free;
        static int n;
        static int k;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[k];
            free = new int[n];
            for (int i = 0; i < n; i++)
            {
                free[i] = i + 1;
            }

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
                for (int i = index; i < n; i++)
                {
                    array[index] = free[i];
                    Swap(ref free[index], ref free[i]);
                    GenerateVariations(index + 1);
                    Swap(ref free[index], ref free[i]);
                }
            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int old = v1;
            v1 = v2;
            v2 = old;
        }

        private static void Print()
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}