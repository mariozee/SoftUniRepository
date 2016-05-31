using System;

namespace _15.RubikMatrix
{
    class RubikMatrix
    {
        private static int[,] matrix;

        static void Main()
        {
            string[] dimenctions = Console.ReadLine().Split(' ');
            int rowsCount = int.Parse(dimenctions[0]);
            int columnsCount = int.Parse(dimenctions[1]);
            int iterations = int.Parse(Console.ReadLine());

            matrix = new int[rowsCount, columnsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = columnsCount * row + col + 1;
                }
            }

            for (int i = 0; i < iterations; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');
                Rotate(inputArgs);
            }

            SwapElements();
        }       

        private static void Rotate(string[] inputArgs)
        {
            int dimention = int.Parse(inputArgs[0]);
            string direction = inputArgs[1];
            int moves = int.Parse(inputArgs[2]);

            if (direction == "up" || direction == "down")
            {
                var tempMatrix = (int[,])matrix.Clone();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int newRow = direction == "up" ? (row + matrix.GetLength(0) - (moves % matrix.GetLength(0)))
                        : (row + matrix.GetLength(0) + (moves % matrix.GetLength(0)));
                    newRow %= matrix.GetLength(0);
                    matrix[newRow, dimention] = tempMatrix[row, dimention];
                }
            }
            else if (direction == "left" || direction == "right")
            {
                var tempMatrix = (int[,])matrix.Clone();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int newCol = direction == "left" ? (col + matrix.GetLength(1) - (moves % matrix.GetLength(1)))
                        : (col + matrix.GetLength(1) + (moves % matrix.GetLength(1)));
                    newCol %= matrix.GetLength(1);
                    matrix[dimention, newCol] = tempMatrix[dimention, col];
                }
            }           
        }

        private static void SwapElements()
        {
            for (int rowOuther = 0; rowOuther < matrix.GetLength(0); rowOuther++)
            {
                for (int colOuther = 0; colOuther < matrix.GetLength(1); colOuther++)
                {
                    int element = matrix.GetLength(1) * rowOuther + colOuther + 1;
                    int currentElement = matrix[rowOuther, colOuther];
                    if (matrix[rowOuther, colOuther] != element)
                    {
                        for (int rowInner = 0; rowInner < matrix.GetLength(0); rowInner++)
                        {
                            for (int colInner = 0; colInner < matrix.GetLength(1); colInner++)
                            {
                                if (matrix[rowInner, colInner] == element)
                                {
                                    matrix[rowInner, colInner] = currentElement;
                                    matrix[rowOuther, colOuther] = element;
                                    Console.WriteLine($"Swap ({rowOuther}, {colOuther}) with ({rowInner}, {colInner})");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }
    }
}