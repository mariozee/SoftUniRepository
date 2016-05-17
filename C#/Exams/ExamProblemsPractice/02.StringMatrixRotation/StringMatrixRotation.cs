using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            string degreesInput = Console.ReadLine();
            int degrees = int.Parse(Regex.Match(degreesInput, @"\d+").Value) % 360;
            //Calculates how many times the matrix should be rotated to the right
            //e.g. if degree equal 90 we rotate 1 time right, if it's 180 we rotate 2 times right and so on.
            int rotationsCount = degrees / 90;

            List<String> lines = new List<string>();
            string line = Console.ReadLine();

            while (line != "END")
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            //LINQ for find line with longest lenght
            int maxLineLenght = lines.OrderByDescending(v => v.Length).First().Length;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].PadRight(maxLineLenght, ' ');
            }

            Rotate(lines, maxLineLenght, rotationsCount);
        }

        /// <summary>
        /// Rotating the "matrix".
        /// </summary>
        /// <param name="lines">List of strings represents matrix</param>
        /// <param name="maxLineLenght">integer represent columns count</param>
        /// <param name="rotationsCount">integer represents number of all rotations that shoud be made</param>
        private static void Rotate(List<string> lines, int maxLineLenght, int rotationsCount)
        {            
            int rows = lines.Count;
            int cols = maxLineLenght;

            //Rotates the "matrix" 90 degrees at a time.
            for (int rotation = 0; rotation < rotationsCount; rotation++)
            {
                //Holds values of newly created matrix.
                List<String> tempLines = new List<string>();

                for (int i = 0; i < cols; i++)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int j = rows - 1; j >= 0; j--)
                    {
                        //Concataned all chars from all rows on current column.
                        sb.Append(lines[j][i]);
                    }

                    tempLines.Add(sb.ToString());
                }

                //Swaping matrix dimentions
                int temp = rows;
                rows = cols;
                cols = temp;

                lines = tempLines;
            }

            Print(lines);
        }

        /// <summary>
        /// Print newly created "matrix" ay the end of all rotations
        /// </summary>
        private static void Print(List<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}