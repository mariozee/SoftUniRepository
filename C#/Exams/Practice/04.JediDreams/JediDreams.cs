using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.JediDreams
{
    class JediDreams
    {
        static SortedDictionary<string, List<string>> methods = new SortedDictionary<string, List<string>>();

        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            string line = string.Empty;
            for (int i = 0; i < linesCount; i++)
            {
                line = Console.ReadLine();
                sb.AppendLine(line);
            }

            string pattern = @"static\s.+\s([A-Za-z]*[A-Z][a-zA-Z]*)\s*\(|([A-Za-z]*[A-Z][a-zA-Z]*)\s*\(";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(sb.ToString());

            string generalMethod = string.Empty;
            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    generalMethod = match.Groups[1].Value;
                    if (!methods.ContainsKey(generalMethod))
                    {
                        methods.Add(generalMethod, new List<string>());
                    }
                }

                if (match.Groups[2].Success)
                {
                    if (methods.ContainsKey(generalMethod))
                    {
                        methods[generalMethod].Add(match.Groups[2].Value);
                    }
                }
            }

            var sortedMethods = methods.OrderByDescending(x => x.Value.Count);
            foreach (var pair in sortedMethods)
            {
                if (pair.Key == string.Empty)
                {
                    continue;
                }

                if (pair.Value.Count > 0)
                {
                    pair.Value.Sort();
                    Console.WriteLine("{0} -> {1} -> {2}"
                    , pair.Key, pair.Value.Count, string.Join(", ", pair.Value));
                }
                else
                {
                    Console.WriteLine("{0} -> None", pair.Key);
                }
            }
        }
    }
}