using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string message)
            : base(message)
        {
        }
    }
}
