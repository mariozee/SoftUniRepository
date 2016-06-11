using System;
using System.IO;

namespace BashSoft
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");
            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidPath);
            }            
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    Console.WriteLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidPath);
                }

                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }

        private static string[] GetLineWithPossibleMismatches(string[] actualOutputString, string[] expectedOutputString, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            int minOutputLines = actualOutputString.Length;
            if (actualOutputString.Length != expectedOutputString.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputString.Length, expectedOutputString.Length);
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputString[index];
                string expectedLine = expectedOutputString[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at line {index} -- expected: \"{expectedLine}\", actual \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }
    }
}