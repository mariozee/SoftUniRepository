using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Exceptions
{
    public class InvalidPositionException : GameException
    {
        public InvalidPositionException(string message)
            : base(message)
        {
        }
    }
}
