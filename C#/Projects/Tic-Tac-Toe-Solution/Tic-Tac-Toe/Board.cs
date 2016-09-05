using System;
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

        public int OplayerWins = 0;
        public int XplayerWins = 0;

        public int playersTurn = X;

        public int GetPlayerForTuen()
        {
            return this.playersTurn;
        }

        public int GetOwins()
        {
            return this.OplayerWins;
        }
        
        public int GetXwins()
        {
            return this.XplayerWins;
        }

        private int movesMade = 0;

        private Holder[,] holders; 

        public void InitBoard()
        {
            this.holders = new Holder[3, 3];
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
                            this.XplayerWins++;
                            MessageBox.Show("X won!");
                            this.Restart();
                        }

                        this.playersTurn = O;
                    }
                    else
                    {
                        GFX.DrawO(new Point(x, y));
                        this.holders[x, y].SetValue(O);
                        if (DetectRow())
                        {
                            this.OplayerWins++;
                            MessageBox.Show("O won!");
                            this.Restart();
                        }

                        this.playersTurn = X;
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

        public void Restart()
        {
            InitBoard();
            GFX.SetUpCanvas();
        }
    }    
}
