using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.RadioactivMutantVampireBunnies
{
    class RadioactivMutantVampireBunnies
    {
        static void Main()
        {            
            Dictionary<char, int[]> directionsMap = new Dictionary<char, int[]>()
            {
                { 'U', new int[] {0, -1} },
                { 'D', new int[] {0, 1} },
                { 'L', new int[] {1, -1} },
                { 'R', new int[] {1, 1} }
            };

            string[] dimentions = Console.ReadLine().Split(' ');
            int rowsNumber = int.Parse(dimentions[0]);
            int columnsNumber = int.Parse(dimentions[1]);

            char[][] matrix = new char[rowsNumber][];
            char[][] matrixCopy = new char[rowsNumber][];

            int[] playerCoordinates = new int[2];
            for (int row = 0; row < rowsNumber; row++)
            {
                string line = Console.ReadLine();
                matrix[row] = line.ToCharArray();
                if (matrix[row].Contains('P'))
                {
                    playerCoordinates[0] = row;
                    playerCoordinates[1] = line.IndexOf('P');
                }
            }

            bool isGameEnd = false;
            bool isPlayerWon = false;

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                int dimention = directionsMap[directions[i]][0];
                int step = directionsMap[directions[i]][1];

                playerCoordinates[dimention] += step;

                int endOfMatrix = dimention == 0 ? rowsNumber : columnsNumber;
                if (playerCoordinates[dimention] < 0 ||
                    playerCoordinates[dimention] == endOfMatrix)
                {
                    playerCoordinates[dimention] -= step;
                    matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
                    isGameEnd = true;
                    isPlayerWon = true;
                }
                else if (matrix[playerCoordinates[0]][playerCoordinates[1]] == 'B')
                {
                    isGameEnd = true;
                }
                else
                {
                    matrix[playerCoordinates[0]][playerCoordinates[1]] = 'P';
                    playerCoordinates[dimention] -= step;
                    matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
                    playerCoordinates[dimention] += step;
                }

                for (int row = 0; row < rowsNumber; row++)
                {
                    matrixCopy[row] = (char[])matrix[row].Clone();
                }

                for (int row = 0; row < rowsNumber; row++)
                {
                    for (int col = 0; col < columnsNumber; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            matrixCopy[Math.Min(row + 1, rowsNumber - 1)][col] = 'B';
                            matrixCopy[Math.Max(row - 1, 0)][col] = 'B';
                            matrixCopy[row][Math.Min(col + 1, columnsNumber - 1)] = 'B';
                            matrixCopy[row][Math.Max(col - 1, 0)] = 'B';                            
                        }
                    }
                }

                if (matrixCopy[playerCoordinates[0]][playerCoordinates[1]] == 'B')
                {
                    isGameEnd = true;
                }

                for (int row = 0; row < rowsNumber; row++)
                {
                    matrix[row] = (char[])matrixCopy[row].Clone();
                }

                if (isGameEnd)
                {
                    break;
                }
            }

            PrintResult(rowsNumber, isPlayerWon, playerCoordinates, matrix);
        }

        private static void PrintResult(int rowsNumber, bool isPlayerWin, int[] playerCoordinates, char[][] matrix)
        {
            for (int row = 0; row < rowsNumber; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }

            Console.WriteLine(string.Format("{0}: {1} {2}"
                , isPlayerWin ? "won" : "dead", playerCoordinates[0], playerCoordinates[1]));
        }
    }
}