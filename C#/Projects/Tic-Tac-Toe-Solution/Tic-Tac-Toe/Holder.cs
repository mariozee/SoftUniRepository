using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
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
