using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseFolder(string path)
        {
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolder = new Queue<string>();
            subFolder.Enqueue(path);

            while (subFolder.Count != 0)
            {
                string currentPath = subFolder.Dequeue();             
                int identaion = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identaion)}{currentPath}");

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolder.Enqueue(directoryPath);
                }               
            }
        }
    }    
}