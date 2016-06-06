using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.PathsBetweenCellsInMatrix
{
    class PathsBetweenCells
    {
        static Stack<string> steps = new Stack<string>();
        static int exitsCount = 0;       

        static void Main()
        {         
            char[,] matrix = new char[,]
            {
                { 's', ' ', ' ', ' ', ' ', ' '},
                { ' ', '*', '*', ' ', '*', ' '},
                { ' ', '*', '*', ' ', '*', ' '},
                { ' ', '*', 'e', ' ', ' ', ' '},
                { ' ', ' ', ' ', '*', ' ', ' '}
            };

            FindPath(matrix, 0, 0, "");
            Console.WriteLine("Total paths found: " + exitsCount);
        }

        private static void FindPath(char[,] matrix, int row, int col, string dir)
        {
            if (!IsValidPosition(matrix, row, col))
            {
                return;
            }

            if (matrix[row, col] == '*')
            {
                return;
            }

            if (matrix[row, col] == '.')
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                steps.Push(dir);
                exitsCount++;
                PrintSteps();
                steps.Pop();
                return;
            }

            steps.Push(dir);
            matrix[row, col] = '.';

            FindPath(matrix, row, col + 1, "R");
            FindPath(matrix, row, col - 1, "L");
            FindPath(matrix, row - 1, col, "U");
            FindPath(matrix, row + 1, col, "D");         
            
            steps.Pop();
            matrix[row, col] = ' ';
        }

        private static void PrintSteps()
        {
            Console.WriteLine(string.Join("", steps.Reverse()));
        }

        private static bool IsValidPosition(char[,] matrix, int row, int col)
        {
            bool isValidRow = row < matrix.GetLength(0) && row > -1;
            bool isValidCol = col < matrix.GetLength(1) && col > -1;

            return isValidCol && isValidRow;
        }
    }
}