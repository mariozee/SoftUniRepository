namespace _01.GenericBox
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var elements = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                var box = new Box<string>(text);
                elements.Add(box);
            }

            string[] indexesToSwap = Console.ReadLine().Split();
            int a = int.Parse(indexesToSwap[0]);
            int b = int.Parse(indexesToSwap[1]);

            Swap(elements, a, b);

            foreach (var element in elements)
            {
                Console.WriteLine(element.ToString());
            }

            Console.Read();
        }

        private static void Swap<T>(List<T> elements, int a, int b)
        {
            var temp = elements[a];
            elements[a] = elements[b];
            elements[b] = temp;
        }

        public void GetWhatever<T>() where T : IComparable
        {

        }

    }
}
