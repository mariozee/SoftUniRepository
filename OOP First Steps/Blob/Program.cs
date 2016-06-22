using System.Text;
using Blob.Core;
using Blob.Interfaces;
using Blob.IO;

namespace Blob
{
    class Program
    {
        static void Main()
        {
            IInputReader inputReader = new ConsoleInputReader();
            IOutputWriter outputWriter = new ConsoleOutputWriter();

            IEngine engine = new Engine(inputReader, outputWriter);

            engine.Run();
        }
    }
}
