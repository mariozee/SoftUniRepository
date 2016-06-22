using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain.Core
{
    public class ConsoleWriter : IOutputWriter
    {
        private readonly StringBuilder outputBuffer;

        public ConsoleWriter()
        {
            this.outputBuffer = new StringBuilder();
        }

        public bool AutoFlush { get; set; }

        public void Write(string line)
        {
            this.outputBuffer.AppendLine(line);

            if (this.AutoFlush)
            {
                this.Flush();
            }
        }

        public void Flush()
        {
            Console.Write(this.outputBuffer);
            this.outputBuffer.Clear();
        }
    }
}
