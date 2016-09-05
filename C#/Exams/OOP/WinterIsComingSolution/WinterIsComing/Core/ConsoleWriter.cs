namespace WinterIsComing.Core
{
    using System;
    using Interfaces;

    class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
