using System;
using System.Collections.Generic;

namespace _11.LogsAggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            Dictionary<string, SortedSet<string>> userLogs
                = new Dictionary<string, SortedSet<string>>();

            SortedDictionary<string, int> logDuration = new SortedDictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');
                string ip = inputArgs[0];
                string name = inputArgs[1];
                int duration = int.Parse(inputArgs[2]);

                if (!userLogs.ContainsKey(name))
                {
                    userLogs.Add(name, new SortedSet<string>());
                    logDuration.Add(name, 0);
                }

                userLogs[name].Add(ip);
                logDuration[name] += duration;
            }

            foreach (var pair in logDuration)
            {
                Console.Write($"{pair.Key}: {pair.Value} ");
                Console.WriteLine("[" + String.Join(", ", userLogs[pair.Key]) + "]");
            }
        }
    }
}
