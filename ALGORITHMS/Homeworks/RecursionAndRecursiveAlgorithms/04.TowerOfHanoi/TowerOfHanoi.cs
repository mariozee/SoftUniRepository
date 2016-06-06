using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TowerOfHanoi
{
    class TowerOfHanoi
    {
        static void Main()
        {
            //int numberOfDisks = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, 4);

            Stack<int> source = new Stack<int>(range.Reverse());
            Stack<int> spare = new Stack<int>();
            Stack<int> destination = new Stack<int>();
            MoveDisks(4, source, destination, spare);
            Console.WriteLine(string.Join(" ", destination));
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                destination.Push(bottomDisk);
                source.Pop();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);

                destination.Push(bottomDisk);
                source.Pop();

                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
    }
}