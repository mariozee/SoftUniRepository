using System;

namespace _02.JediGalaxy
{
    class JediGalaxy
    {
        static long totalSum = 0;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[,] matrix = new int[rows, cols];

            //Init matrix
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rows * row + col;
                }
            }

            int iterationCounter = 0;
            bool isGood = false;
            bool isEvil = false;
            int goodRow = 0;
            int goodCol = 0;
            int goodDiagonal = 0;
            int evilRow = 0;
            int evilCol = 0;
            int evilDiagonal = 0;

            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                //If iteration number is even we read Ivo's row and column and also taka the current diagonal.
                //Left diagonals (Ivo's diagonals or Good diagonals) of the matrix are calculated by 
                //current row + current column. The result should be a number between 0 and max valid row + max valid column
                //otherwise diagonal does not hit the matrix.
                //If iteration number is odd we read Evil row and column.
                //Right diagonals or Evil diagonal are calculated by current column - current row. The range of the result
                //must be from negative value of max valid row to max valid column.
                if (iterationCounter % 2 == 0)
                {
                    goodRow = int.Parse(command.Split()[0]);
                    goodCol = int.Parse(command.Split()[1]);
                    goodDiagonal = goodRow + goodCol;
                    isGood = true;
                }
                else
                {
                    evilRow = int.Parse(command.Split()[0]);
                    evilCol = int.Parse(command.Split()[1]);
                    evilDiagonal = evilCol - evilRow;
                    isEvil = true;
                }

                //If the both inputs are read we are ready to continue with the tough part.
                if (isEvil && isGood)
                {
                    //Boolean variables to check if given diagonal hit the matrix.
                    bool isEvilDiagonalInTheMatrix = evilDiagonal < cols && evilDiagonal > (rows * -1);
                    bool isGoodDiagonalInTheMatrix = goodDiagonal <= rows + cols - 2 && goodDiagonal >= 0;

                    if (isEvilDiagonalInTheMatrix && isGoodDiagonalInTheMatrix)
                    {
                        DestroyDiagonal(matrix, rows, cols, evilDiagonal);
                        CollectDiagonal(matrix, rows, cols, goodDiagonal);
                    }
                    else if (isEvilDiagonalInTheMatrix || isGoodDiagonalInTheMatrix)
                    {
                        if (isEvilDiagonalInTheMatrix)
                            DestroyDiagonal(matrix, rows, cols, evilDiagonal);
                        else
                            CollectDiagonal(matrix, rows, cols, goodDiagonal);
                    }

                    isEvil = false;
                    isGood = false;
                }

                iterationCounter++;
            }

            Console.WriteLine(totalSum);
        }

        //Ivo's diagonal or Good diagonal
        //Method thath search for first cell in the diagonal that is in tha matrix and
        //then collect the value from every cell in that diagonal
        private static void CollectDiagonal(int[,] matrix, int rows, int cols, int goodDiagonal)
        {
            int currentRow = rows;
            int currentCol = -1;

            while (currentRow >= rows)
            {
                currentCol++;
                currentRow = goodDiagonal - currentCol;
            }

            while (currentCol < cols && currentRow >= 0)
            {
                totalSum += matrix[currentRow, currentCol];
                currentCol++;
                currentRow--;
            }
        }

        //Evil diagonal
        //Method thath search for first cell in the diagonal that is in tha matrix and
        //then detroys every cell in that diagonal
        private static void DestroyDiagonal(int[,] matrix, int rows, int cols, int evilDiagonal)
        {
            int currentRow = rows;
            int currentCol = cols;

            while (currentRow >= rows)
            {
                currentCol--;
                currentRow = currentCol - evilDiagonal;
            }

            while (currentCol >= 0 && currentRow >= 0)
            {
                matrix[currentRow, currentCol] = 0;
                currentCol--;
                currentRow--;
            }
        }
    }
}