using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeMain
    {
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight;
            //Масив от Позиции в който задаваме стойности-изместване за разли1ните посоки
            Position[] directions = new Position[]
            {
                new Position(0, 1), //right
                new Position(0, -1), //left
                new Position(1, 0), //down
                new Position(-1, 0) //up
            };

            int direction = 0;
            int score = 0;

            Random randomNumberGenerator = new Random();

            Position food = new Position(randomNumberGenerator.Next(1, Console.WindowHeight),
                randomNumberGenerator.Next(0, Console.WindowWidth));

            //Опашка - Queue представлява масив на който лесно може да контролираме
            //първата и последната позиция
            //Опашка от Позиции - пази няколко последователно вкарани позиции които
            //предтавляват тялото за змията
            Queue<Position> snakeElelments = new Queue<Position>();

            //С този цикъл задаваме всички шест позиции които представляват 
            //първоначлното тяло на змията
            for (int i = 0; i < 11; i++)
            {
                snakeElelments.Enqueue(new Position(1, i));
            }

            while (true)
            {
                //Това условие гласи, че ако има натиснат клавиш трябва да се
                //изпълни действието в него
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    direction = Position.GetDirection(input, direction);
                }

                //Главата на змията я задаваме да бъде последният елемент
                //от Опашката ни от Позиции
                Position snakeHead = snakeElelments.Last();

                //Следващата посока за която вече имаме данните от if 
                //конструкцията по горе.
                Position nextDirection = directions[direction];

                //Променлива която пази новата глава на змията на новополучената позиция
                Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                    snakeHead.Col + nextDirection.Col);

                if (snakeNewHead.Col >= Console.WindowWidth || snakeNewHead.Col < Console.WindowLeft
                    || (snakeNewHead.Row >= Console.WindowHeight) || (snakeNewHead.Row < Console.WindowTop)
                    || snakeElelments.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Game Over!");
                    Console.SetCursorPosition(0, 1);
                    break;
                }

                //Добавяме новата глава на змията в Опашката ни от Позиции
                snakeElelments.Enqueue(snakeNewHead);

                //Изчистваме всичко от конзолата до момента
                Console.Clear();
                Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
                Console.Write(" ");

                PrintSnake(snakeElelments);

                if (snakeNewHead.Col == food.Col && snakeNewHead.Row == food.Row)   //7.49 16.18 23.21
                {
                    food = new Position(randomNumberGenerator.Next(1, Console.WindowHeight),
                    randomNumberGenerator.Next(0, Console.WindowWidth));
                    score++;
                }
                else
                {
                    //С долната функция премахваме първият елемент от Опашката ни
                    //от Позиции който се явява края на змията
                    snakeElelments.Dequeue();
                }
                string scoreStr = string.Format("SCORE: {0}", score * 150);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.SetCursorPosition(0, 0);

                Console.Write(scoreStr.PadRight(Console.WindowWidth));

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(food.Col, food.Row);
                Console.Write("@");

                //Приспиваме процесора за N мили секунди
                Thread.Sleep(100);
            }
        }

        static void PrintSnake(Queue<Position> pos)
        {
            foreach (Position p in pos)
            {
                Console.SetCursorPosition(p.Col, p.Row);
                Console.Write("O");
            }
        }
    }
}
