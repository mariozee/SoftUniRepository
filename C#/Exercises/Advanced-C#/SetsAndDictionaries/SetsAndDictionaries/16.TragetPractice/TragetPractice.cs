using System;

namespace _16.TragetPractice
{
    class TragetPractice
    {
        static char[,] matrix;

        static void Main()
        {
            string[] dimentions = Console.ReadLine().Split(' ');
            int rowsCount = int.Parse(dimentions[0]);
            int colsCount = int.Parse(dimentions[1]);

            string snake = Console.ReadLine();

            string[] shotParams = Console.ReadLine().Split(' ');
            int rowOfImapct = int.Parse(shotParams[0]);
            int colOfImpact = int.Parse(shotParams[1]);
            int radius = int.Parse(shotParams[2]);

            matrix = new char[rowsCount, colsCount];

            FillMatrix(snake);
            ShootAt(rowOfImapct, colOfImpact, radius);
            MakeItRain();
            PrintMatrix();
        }

        private static void FillMatrix(string snake)
        {
            int index = 0;
            bool isDirectionLeft = true;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (isDirectionLeft)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[index % snake.Length];
                        index++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[index % snake.Length];
                        index++;
                    }
                }

                isDirectionLeft = !isDirectionLeft;
            }
        }

        private static void ShootAt(int rowOfImapct, int colOfImpact, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Math.Pow(row - rowOfImapct, 2) + Math.Pow(col - colOfImpact, 2) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void MakeItRain()
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                    {
                        matrix[row + 1, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                        row = -1;
                    }
                }
            }
        }        

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }        
    }
}