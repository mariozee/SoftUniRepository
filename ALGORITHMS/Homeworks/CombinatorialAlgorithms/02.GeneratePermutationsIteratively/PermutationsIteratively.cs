using System;

namespace _02.GeneratePermutationsIteratively
{
    class PermutationsIteratively
    {
        static int n;
        static int permutationsCount = 0;

        static void Main()
        {            
            n = int.Parse(Console.ReadLine());
            var start = DateTime.Now;
            int[] aArray = new int[n];
            int[] pArray = new int[n];
            int i;
            int j;
            int tmp;

            for (i = 0; i < n; i++)
            {
                aArray[i] = i + 1;
                pArray[i] = 0;
            }
            Display(aArray, 0, 0);
            i = 1;

            while (i < n)
            {
                if (pArray[i] < i)
                {
                    j = i % 2 * pArray[i];
                    tmp = aArray[j];
                    aArray[j] = aArray[i];
                    aArray[i] = tmp;
                    Display(aArray, j, i);
                    pArray[i]++;
                    i = 1;
                }
                else
                {
                    pArray[i] = 0;
                    i++;
                }
            }
            var end = DateTime.Now;            
            Console.WriteLine(end - start);
            Console.WriteLine("Total permutations: " + permutationsCount);
        }

        private static void Display(int[] aArray, int j, int i)
        {
            Console.WriteLine(string.Join(", ", aArray));
            permutationsCount++;
            //for (int x = 0; x < n; x++)
            //{
            //    Console.Write(aArray[x] + " ");
            //    Console.WriteLine("     swapped({0}, {1})", j, i);
            //}           
        }
    }
}
