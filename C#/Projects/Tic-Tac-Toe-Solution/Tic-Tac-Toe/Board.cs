﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    class Board
    {
        public const int X = 0;
        public const int O = 1;
        public const int B = 2;

        private int movesMade = 0;

        private Holder[,] holders = new Holder[3, 3];

        public void InitBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    this.holders[x, y] = new Holder();
                    this.holders[x, y].SetValue(B);
                    this.holders[x, y].SetLocation(new Point(x, y));
                }
            }
        }

        public void DetectHit(Point location)
        {
            if (location.Y <= 500)
            {
                int x = 0;
                int y = 0;

                if (location.X < 167)
                {
                    x = 0;
                }
                else if (location.X > 167 && location.X < 334)
                {
                    x = 1;
                }
                else if (location.X > 334)
                {
                    x = 2;
                }

                if (location.Y < 167)
                {
                    y = 0;
                }
                else if (location.Y > 167 && location.Y < 334)
                {
                    y = 1;
                }
                else if (location.Y > 334 && location.Y < 500)
                {
                    y = 2;
                }

                if (this.holders[x, y].GetValue() == B)
                {
                    if (this.movesMade % 2 == 0)
                    {
                        GFX.DrawX(new Point(x, y));
                        this.holders[x, y].SetValue(X);
                        if (DetectRow())
                        {
                            MessageBox.Show("X won!");
                        }
                    }
                    else
                    {
                        GFX.DrawO(new Point(x, y));
                        this.holders[x, y].SetValue(O);
                        if (DetectRow())
                        {
                            MessageBox.Show("O won!");
                        }
                    }

                    this.movesMade++;
                }

            }
        }

        public bool DetectRow()
        {
            for (int index = 0; index < 3; index++)
            {
                //X check by columns
                if (this.holders[index, 0].GetValue() == X && this.holders[index, 1].GetValue() == X && this.holders[index, 2].GetValue() == X)
                {
                    return true;
                }

                //O check by columns
                if (this.holders[index, 0].GetValue() == O && this.holders[index, 1].GetValue() == O && this.holders[index, 2].GetValue() == O)
                {
                    return true;
                }

                //X check by rows
                if (this.holders[0, index].GetValue() == O && this.holders[1, index].GetValue() == O && this.holders[2, index].GetValue() == O)
                {
                    return true;
                }

                //O check by rows
                if (this.holders[0, index].GetValue() == X && this.holders[1, index].GetValue() == X && this.holders[2, index].GetValue() == X)
                {
                    return true;
                }

                switch (index)
                {
                    case 0:
                        //X check by right diagonal
                        if (this.holders[index, 0].GetValue() == X && this.holders[index + 1, 1].GetValue() == X && this.holders[index + 2, 2].GetValue() == X)
                        {
                            return true;
                        }

                        //O check by right diagonal
                        if (this.holders[index, 0].GetValue() == O && this.holders[index + 1, 1].GetValue() == O && this.holders[index + 2, 2].GetValue() == O)
                        {
                            return true;
                        }
                        break;

                    case 2:
                        //X check by left diagonal
                        if (this.holders[index, 0].GetValue() == X && this.holders[index - 1, 1].GetValue() == X && this.holders[index - 2, 2].GetValue() == X)
                        {
                            return true;
                        }

                        //O check by left diagonal
                        if (this.holders[index, 0].GetValue() == O && this.holders[index - 1, 1].GetValue() == O && this.holders[index - 2, 2].GetValue() == O)
                        {
                            return true;
                        }
                        break;
                }
            }

            return false;
        }
    }

    class Holder
    {
        private Point location;
        private int value = Board.B;

        public void SetLocation(Point p)
        {
            this.location = p;
        }

        public Point GetLocation()
        {
            return this.location;
        }

        public void SetValue(int i)
        {
            this.value = i;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
