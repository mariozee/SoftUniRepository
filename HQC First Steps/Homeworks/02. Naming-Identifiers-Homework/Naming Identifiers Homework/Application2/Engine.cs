namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    class Engine
    {
        public void Run()
        {
            const int maxGameScore = 35;

            string command = string.Empty;
            char[,] field = DrawInnerField();
            char[,] bombsPosition = PutBombs();
            int playerPoints = 0;
            bool isBombHit = false;
            List<Stats> playersStats = new List<Stats>(6);
            int row = 0;
            int col = 0;
            bool flag = true;
            bool isMaxScoreReached = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Try to discover all mine free cells."
                        + " Commands:/n 'rectords' - Shows Scoreboard/n 'restart' Restart current game/n 'exit' Exit game");
                    DrawOutherField(field);
                    flag = false;
                }

                Console.Write("Type row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "records":
                        AddPlayerScore(playersStats);
                        break;
                    case "restart":
                        field = DrawInnerField();
                        bombsPosition = PutBombs();
                        DrawOutherField(field);
                        isBombHit = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Buy!");
                        break;
                    case "turn":
                        if (bombsPosition[row, col] != '*')
                        {
                            if (bombsPosition[row, col] == '-')
                            {
                                PrintNumbersOfMinesArround(field, bombsPosition, row, col);
                                playerPoints++;
                            }

                            if (maxGameScore == playerPoints)
                            {
                                isMaxScoreReached = true;
                            }
                            else
                            {
                                DrawOutherField(field);
                            }
                        }
                        else
                        {
                            isBombHit = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid Command\n");
                        break;
                }

                if (isBombHit)
                {
                    DrawOutherField(bombsPosition);
                    Console.Write("\nBOOOM! You step on mine and you are dead. Your score is {0} points. " +
                        "Type nick name: ", playerPoints);
                    string playerName = Console.ReadLine();
                    Stats stats = new Stats(playerName, playerPoints);
                    if (playersStats.Count < 5)
                    {
                        playersStats.Add(stats);
                    }
                    else
                    {
                        for (int i = 0; i < playersStats.Count; i++)
                        {
                            if (playersStats[i].PlayerPoints < stats.PlayerPoints)
                            {
                                playersStats.Insert(i, stats);
                                playersStats.RemoveAt(playersStats.Count - 1);
                                break;
                            }
                        }
                    }

                    playersStats.Sort((Stats r1, Stats r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    playersStats.Sort((Stats r1, Stats r2) => r2.PlayerPoints.CompareTo(r1.PlayerPoints));
                    AddPlayerScore(playersStats);

                    field = DrawInnerField();
                    bombsPosition = PutBombs();
                    playerPoints = 0;
                    isBombHit = false;
                    flag = true;
                }

                if (isMaxScoreReached)
                {
                    Console.WriteLine("\nBRAVOOO! You opened all 35 cells.");
                    DrawOutherField(bombsPosition);
                    Console.WriteLine("Type your name here chanpion: ");
                    string playerName = Console.ReadLine();
                    Stats stats = new Stats(playerName, playerPoints);
                    playersStats.Add(stats);
                    AddPlayerScore(playersStats);

                    field = DrawInnerField();
                    bombsPosition = PutBombs();
                    playerPoints = 0;
                    isMaxScoreReached = false;
                    flag = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Refactored by M3.");
            Console.Read();
        }

        private static void AddPlayerScore(List<Stats> stats)
        {
            Console.WriteLine("\nPoints:");
            if (stats.Count > 0)
            {
                for (int i = 0; i < stats.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, stats[i].PlayerName, stats[i].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Scoreboard is empy!\n");
            }
        }

        private static void PrintNumbersOfMinesArround(char[,] field, char[,] bombsPosition, int row, int col)
        {
            char minesArroundCount = CheckForMinesArround(bombsPosition, row, col);
            bombsPosition[row, col] = minesArroundCount;
            field[row, col] = minesArroundCount;
        }

        private static void DrawOutherField(char[,] board)
        {
            int rowsCount = board.GetLength(0);
            int colsCount = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowsCount; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] DrawInnerField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] innerField = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    innerField[i, j] = '?';
                }
            }

            return innerField;
        }

        private static char[,] PutBombs()
        {
            int row = 5;
            int col = 10;
            char[,] bombField = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    bombField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random randomBombGenerator = new Random();
                int randomBomb = randomBombGenerator.Next(50);
                if (!bombs.Contains(randomBomb))
                {
                    bombs.Add(randomBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int bombCol = bomb / col;
                int bombRow = bomb % col;
                if (bombRow == 0 && bomb != 0)
                {
                    bombCol--;
                    bombRow = col;
                }
                else
                {
                    bombRow++;
                }

                bombField[bombCol, bombRow - 1] = '*';
            }

            return bombField;
        }

        private static void SetMinesArroundCount(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesCount = CheckForMinesArround(field, i, j);
                        field[i, j] = minesCount;
                    }
                }
            }
        }

        private static char CheckForMinesArround(char[,] matrix, int rowEntered, int colEntered)
        {
            int minesArroundCount = 0;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (rowEntered - 1 >= 0)
            {
                if (matrix[rowEntered - 1, colEntered] == '*')
                {
                    minesArroundCount++;
                }
            }

            if (rowEntered + 1 < row)
            {
                if (matrix[rowEntered + 1, colEntered] == '*')
                {
                    minesArroundCount++;
                }
            }

            if (colEntered - 1 >= 0)
            {
                if (matrix[rowEntered, colEntered - 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            if (colEntered + 1 < col)
            {
                if (matrix[rowEntered, colEntered + 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            if ((rowEntered - 1 >= 0) && (colEntered - 1 >= 0))
            {
                if (matrix[rowEntered - 1, colEntered - 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            if ((rowEntered - 1 >= 0) && (colEntered + 1 < col))
            {
                if (matrix[rowEntered - 1, colEntered + 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            if ((rowEntered + 1 < row) && (colEntered - 1 >= 0))
            {
                if (matrix[rowEntered + 1, colEntered - 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            if ((rowEntered + 1 < row) && (colEntered + 1 < col))
            {
                if (matrix[rowEntered + 1, colEntered + 1] == '*')
                {
                    minesArroundCount++;
                }
            }

            return char.Parse(minesArroundCount.ToString());
        }
    }
}
