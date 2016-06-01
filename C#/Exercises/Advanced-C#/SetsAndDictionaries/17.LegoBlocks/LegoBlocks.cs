using System;
using System.Linq;

namespace _17.LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            int totalRows = int.Parse(Console.ReadLine());

            string[][] firstMatrix = new string[totalRows][];
            string[][] secondMatrix = new string[totalRows][];
            string[][] combined = new string[totalRows][];

            for (int row = 0; row < totalRows; row++)
            {
                firstMatrix[row] = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < totalRows; row++)
            {
                secondMatrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < totalRows; row++)
            {
                Array.Reverse(secondMatrix[row]);
                combined[row] = firstMatrix[row].Concat(secondMatrix[row]).ToArray();
            }                    

            for (int row = 0; row < totalRows - 1; row++)
            {
                if (combined[row].Length != combined[row + 1].Length)
                {
                    PrintCellsCount(combined);
                    return;
                }
            }

            PrintCombinedMatrix(combined);
        }      

        private static void PrintCellsCount(string[][] combined)
        {
            int totalCells = 0;
            for (int row = 0; row < combined.GetLength(0); row++)
            {
                totalCells += combined[row].Length;
            }

            Console.WriteLine("The total number of cells is: " + totalCells);
        }

        private static void PrintCombinedMatrix(string[][] combined)
        {
            for (int row = 0; row < combined.GetLength(0); row++)
            {
                Console.WriteLine("[" + string.Join(", ", combined[row]) + "]");
            }
        }
    }
}