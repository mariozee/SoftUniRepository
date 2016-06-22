using System;
using Blob.Interfaces;

namespace Blob.IO
{
    public class ConsoleInputReader : IInputReader
    {
        public string Readline()
        {
            var consoleLine = Console.ReadLine();

            return consoleLine;
        }
    }
}
