using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ConnectedAreasInMatrix
{
    public class ConnectedAreasInMatrix
    {
        private const char EmptyCell = ' ';
        private const char MarkedCell = '-';
        private const char Wall = '*';
        private static char[][] matrix;
        private static int size = 0;
        private static HashSet<Area> areas = new HashSet<Area>();

        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            matrix = new char[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            FindArea(0, 0);
            var sortedAreas = areas.OrderByDescending(x => x);
            int counter = 0;
            Console.WriteLine("Total areas found: " + sortedAreas.Count());
            foreach (var area in sortedAreas)
            {
                counter++;
                Console.WriteLine($"Area #{counter} at ({area.TopRow}, {area.TopCol}), size: {area.Size}");
            }
        }

        private static void FindArea(int row, int col)
        {
            if (row == matrix.Length)
            {
                return;
            }

            if (col == matrix[0].Length)
            {
                FindArea(row + 1, 0);
                return;
            }

            if (matrix[row][col] == ' ')
            {
                size = 0;
                GetSize(row, col);
                areas.Add(new Area(row, col, size));
            }

            FindArea(row, col + 1);
        }

        private static void GetSize(int row, int col)
        {
            if (!IsValid(row, col))
            {
                return;
            }

            if (matrix[row][col] == '*' || matrix[row][col] == '-')
            {
                return;
            }

            if (matrix[row][col] == ' ')
            {
                matrix[row][col] = '-';
                size++;
            }

            GetSize(row + 1, col); //Down
            GetSize(row - 1, col); //Up
            GetSize(row, col + 1); //Right
            GetSize(row, col - 1); //Left
        }

        private static bool IsValid(int row, int col)
        {
            bool isRowValid = row < matrix.Length && row > -1;
            bool isColValid = col < matrix[0].Length && col > -1;

            return isRowValid && isColValid;
        }
    }
}