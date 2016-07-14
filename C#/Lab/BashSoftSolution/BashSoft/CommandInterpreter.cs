using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class CommandInterpreter
    {
        public static void IntepredCommand(string input)
        {
            string[] data = input.Split();
            string command = data[0];
            switch (command)
            {
                case "open":
                    
                default:
                    break;
            }
        }
    }
}
