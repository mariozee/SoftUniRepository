using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            string[] array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> printSir = s => Console.WriteLine($"Sir {s}");

            foreach (var sir in array)
            {
                printSir(sir);
            }
        }
    }
}
