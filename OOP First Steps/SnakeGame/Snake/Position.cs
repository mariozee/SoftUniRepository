using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Position
    {
        public int Row;
        public int Col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static int GetDirection(ConsoleKeyInfo userInput, int direction)
        {
            //Структурата ConsoleKeyInfo чака инпут от тип ReadKey()
            if (userInput.Key == ConsoleKey.D)
            {
                if (direction != 1) direction = 0;
            }
            if (userInput.Key == ConsoleKey.A)
            {
                if (direction != 0)  direction = 1;
            }
            if (userInput.Key == ConsoleKey.S)
            {
                if (direction != 3) direction = 2;
            }
            if (userInput.Key == ConsoleKey.W)
            {
                if (direction != 2) direction = 3;
            }
            return direction;
        }
    }
}
