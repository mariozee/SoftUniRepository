using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Interfaces;

namespace BikePartsFactory.IO
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            string message = Console.ReadLine();

            return message;
        }
    }
}
