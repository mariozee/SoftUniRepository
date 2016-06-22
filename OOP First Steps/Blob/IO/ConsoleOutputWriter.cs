using System;
using Blob.Interfaces;

namespace Blob.IO
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void AppendLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
