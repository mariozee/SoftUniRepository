﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.IO
{
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
