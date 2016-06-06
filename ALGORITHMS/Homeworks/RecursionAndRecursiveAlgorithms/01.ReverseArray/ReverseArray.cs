using System;
using System.Linq;

namespace _01.ReverseArray
{
    class ReverseArray
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Reverse(arr, 0, arr.Length - 1);
        }

        private static void Reverse(int[] arr, int firstIndex, int lastIndex)
        {
            if (firstIndex == arr.Length / 2)
            {
                PrintArray(arr);
                return;
            }

            int temp = arr[firstIndex];
            arr[firstIndex] = arr[lastIndex];
            arr[lastIndex] = temp;
            Reverse(arr, firstIndex + 1, lastIndex - 1);
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
