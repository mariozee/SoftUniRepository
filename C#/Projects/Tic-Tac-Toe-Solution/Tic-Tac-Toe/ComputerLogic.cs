using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class ComputerLogic
    {
        public static void DetermineAndPlaceMark(Holder[,] board)
        {
            Holder move = new Holder();
            move.SetValue(Board.O);

            //Check if center is Blank
            if (board[1, 1].GetValue() == Board.B)
            {
                move.SetLocation(new Point(1, 1));
            }
            //Check if there are any open rows two O's
            else if (board[0, 0].GetValue() == Board.O && board[0, 1].GetValue() == Board.O && board[0, 2].GetValue() == Board.B)
            {
                move.SetLocation(new Point(0, 2));
            }
        }
    }
}
