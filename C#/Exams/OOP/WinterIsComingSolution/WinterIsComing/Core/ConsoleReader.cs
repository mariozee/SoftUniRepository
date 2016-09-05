namespace WinterIsComing.Core
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string output = Console.ReadLine();

            return output;
        }
    }
}
