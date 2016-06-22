using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.JediCodeX
{
    class JediCodeX
    {
        static void Main()
        {
            List<string> jedis = new List<string>();
            List<string> messages = new List<string>();

            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine(Console.ReadLine());
            }

            string jediPattern = Console.ReadLine();
            string messagePattern = Console.ReadLine(); 
            
            string pattern = $@"{jediPattern}([A-Za-z]+)|{messagePattern}([A-Za-z0-9])";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success && match.Groups[1].Value.Length == jediPattern.Length)
                {
                    jedis.Add(match.Groups[1].Value);
                }
                 
                if (match.Groups[2].Success && match.Groups[2].Value.Length == messagePattern.Length)
                {
                    messages.Add(match.Groups[2].Value);
                }
            }

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int currentJediIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] - 1 < messages.Count)
                {
                    Console.WriteLine($"{jedis[currentJediIndex]} - {messages[arr[i] - 1]}");
                    currentJediIndex++;
                }

                if (currentJediIndex >= jedis.Count)
                {
                    break;
                }
            }
        }
    }
}