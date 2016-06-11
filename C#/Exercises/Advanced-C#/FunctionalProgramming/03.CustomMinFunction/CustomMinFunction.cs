using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, int> smallestNum = n =>
            {
                int min = Int32.MaxValue;
                foreach (var num in n)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                return min;
            };

            Console.WriteLine(smallestNum(numbers));
        }

        
    }
}
