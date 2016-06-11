using System;
using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseFolder(int depth)
        {
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolder = new Queue<string>();
            subFolder.Enqueue(SessionData.currentPath);

            while (subFolder.Count != 0)
            {
                string currentPath = subFolder.Dequeue();             
                int identaion = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identaion)}{currentPath}");

                if (depth - identaion < 0)
                {
                    break;
                }
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolder.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
                            
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.ForbiddenSymbolContainedInName);
            }
        }

        public static void ChageCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChageCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChageCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            SessionData.currentPath = absolutePath;
        }
    }    
}