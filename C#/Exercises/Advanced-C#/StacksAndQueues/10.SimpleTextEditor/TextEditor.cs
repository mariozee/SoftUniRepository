using System;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    class TextEditor
    {
        static StringBuilder text = new StringBuilder();
        static Stack<string> prevOperationsResults = new Stack<string>();

        static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');

                switch (commandArgs[0])
                {
                    case "1":
                        Append(commandArgs[1]);
                        break;
                    case "2":
                        Erase(int.Parse(commandArgs[1]));
                        break;
                    case "3":
                        char element = ElementAt(int.Parse(commandArgs[1]) - 1);
                        Console.WriteLine(element);
                        break;
                    case "4":
                        Undo();
                        break;
                    default:
                        break;
                }
            }
        }       

        private static void Append(string str)
        {
            prevOperationsResults.Push(text.ToString());
            text.Append(str);
        }

        private static void Erase(int lenght)
        {
            prevOperationsResults.Push(text.ToString());
            int startIndex = text.Length - lenght;
            text.Remove(startIndex, lenght);
        }

        private static char ElementAt(int index)
        {
            char ch = text.ToString()[index];
            return ch;
        }

        private static void Undo()
        {
            text = new StringBuilder(prevOperationsResults.Pop());
        }
    }
}