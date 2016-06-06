using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ConnectedAreasInMatrix
{
    public class ConnectedAreasInMatrix
    {
        private const char EmptyCell = ' ';
        private const char MarkedCell = '-';
        private const char Wall = '*';
        private static char[][] matrix;
        private static int size = 0;

        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            matrix = new char[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            FindArea();
        }

        private static void FindArea()
        {
            int topRow = 0;
            int topCol = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == EmptyCell)
                    {
                        topRow = row;
                        topCol = col;
                        GetSize(topRow, topCol);
                    }
                }
            }
        }

        private static void GetSize(int row, int col)
        {
            if (row >= matrix.Length || 
                row <= -1 || 
                col >= matrix[0].Length || 
                col <= -1)
            {
                return;
            }

            if (matrix[row][col] == Wall)
            {
                return;
            }

            if (matrix[row][col] == MarkedCell)
            {
                return;
            }

            if (matrix[row][col] == EmptyCell)
            {
                size++;
                matrix[row][col] = MarkedCell;
            }

            GetSize(row + 1, col); //Down
            GetSize(row - 1, col); //Up
            GetSize(row, col + 1); //Right
            GetSize(row, col - 1); //Left
        }
    }
}
