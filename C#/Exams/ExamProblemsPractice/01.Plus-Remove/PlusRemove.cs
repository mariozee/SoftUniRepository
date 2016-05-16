using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Plus_Remove
{
    class PlusRemove
    {
        const int UpDefaultCol = 1;
        const int DownDefaultCol = 1;
        const int LeftDefaultCol = 0;
        const int RightDefaultCol = 2;
        const int MiddleDefaultCol = 1;

        /// <summary>
        /// Contains coordinates of all five cells at first avaliable position in the matrix.
        /// </summary>
        static List<int[]> plusArgs = new List<int[]>()
        {
            new int[2] { 0, UpDefaultCol },    //upper element
            new int[2] { 2, DownDefaultCol },  //bottom element
            new int[2] { 1, LeftDefaultCol },  //left element
            new int[2] { 1, RightDefaultCol }, //right element
            new int[2] { 1, MiddleDefaultCol}  //middle elemnt
        };

        /// <summary>
        /// Here we'll store the elements from the input.
        /// </summary>
        static List<List<char>> matrix = new List<List<char>>();

        /// <summary>
        /// Here we'll store coordinates of cells which form a valid plus
        /// </summary>
        static SortedDictionary<int, List<int>> coordinates = new SortedDictionary<int, List<int>>();

        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            //Read and add to our matrix.
            while (line != "END")
            {
                matrix.Add(line.ToCharArray().ToList());
                line = Console.ReadLine();
            }

            //Stops when bottom element row of our plus shape reach the size of the matrix.
            while (plusArgs[1][0] < matrix.Count)
            {
                if (IsGoodPosition())
                {
                    CheckForPlus();

                    //Moving our imaginary plus shape one column to the right.
                    foreach (var arg in plusArgs)
                    {
                        arg[1]++;
                    }
                }
                else
                {
                    //When we reach postion that can NOT create plus shape
                    //we have to bring back default values of columns...
                    plusArgs[0][1] = UpDefaultCol;
                    plusArgs[1][1] = DownDefaultCol;
                    plusArgs[2][1] = LeftDefaultCol;
                    plusArgs[3][1] = RightDefaultCol;
                    plusArgs[4][1] = MiddleDefaultCol;

                    //...and then moving all elements of our imaginary plus shape one row down. 
                    foreach (var arg in plusArgs)
                    {
                        arg[0]++;
                    }
                }
            }

            RemovePlus();
            PrintResult();
        }

        /// <summary>
        /// Checks if current coordinates can form plus shape.
        /// </summary>
        private static bool IsGoodPosition()
        {
            bool areAllGood = true;

            foreach (var arg in plusArgs)
            {
                areAllGood = areAllGood && (arg[1] < matrix[arg[0]].Count);
            }

            return areAllGood;
        }

        /// <summary>
        /// Check if elemnts of the plus shape are equal and can form a valid plus shape.
        /// </summary>
        private static void CheckForPlus()
        {
            for (int i = 0; i < plusArgs.Count - 1; i++)
            {
                if (matrix[plusArgs[i][0]][plusArgs[i][1]].ToString().ToUpper() !=
                    matrix[plusArgs[i + 1][0]][plusArgs[i + 1][1]].ToString().ToUpper())
                {
                    return;
                }
            }

            SaveCoordinats();
        }

        /// <summary>
        /// Saves coordinates to Dictionary for easier removing from the matrix
        /// Key represents row, Value represents all cells that shoud be removed from the matrix on that row.
        /// </summary>
        private static void SaveCoordinats()
        {
            foreach (var arg in plusArgs)
            {
                if (!coordinates.ContainsKey(arg[0]))
                {
                    coordinates.Add(arg[0], new List<int>());
                }

                coordinates[arg[0]].Add(arg[1]);
            }          
        }

        /// <summary>
        /// Removes all coordinates saved in the Dictionary from the matrix
        /// </summary>
        private static void RemovePlus()
        {
            foreach (var pair in coordinates)
            {
                List<int> columns = pair.Value;
                //We use descending order for columns of current row otherwise when start removing
                //elemts it's very likely to end up with Exception
                columns = columns.OrderByDescending(c => c).Distinct().ToList();
                foreach (var col in columns)
                {
                    matrix[pair.Key].RemoveAt(col);
                }
            }
        }
        
        /// <summary>
        /// Just print what is left from the matrix :)
        /// </summary>
        private static void PrintResult()
        {
            foreach (var list in matrix)
            {
                foreach (var element in list)
                {
                    Console.Write(element);
                }

                Console.WriteLine();
            }
        }      
    }
}
