using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomList
{
    public class Startup
    {
        private static bool isRunning;

        static void Main(string[] args)
        {
            CommandInterpreter interpreter = new CommandInterpreter();
            Start(interpreter);
        }

        private static void Start(CommandInterpreter interpreter)
        {
            var list = new CustomList<string>();
            isRunning = true;
            while (isRunning)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string output = interpreter.Dispatch<string>(inputArgs, list);
                if (output != string.Empty)
                {
                    Console.WriteLine(output);
                }
            }
        }

        public static void Stop()
        {
            isRunning = false;
        }
    }
}
