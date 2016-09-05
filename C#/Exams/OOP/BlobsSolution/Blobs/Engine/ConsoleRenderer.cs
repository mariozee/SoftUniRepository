namespace Blobs.Engine
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Text;

    public class ConsoleRenderer : IRenderer
    {
        public IEnumerable<string> Input()
        {
            string currentLine = Console.ReadLine();
            while (currentLine != "drop")
            {
                yield return currentLine;
                currentLine = Console.ReadLine();
            }
        }

        public void Ouptut(IEnumerable<string> output)
        {
            var sb = new StringBuilder();
            foreach (var line in output)
            {
                sb.AppendLine(line);
            }

            Console.Write(sb.ToString());
        }
    }
}
