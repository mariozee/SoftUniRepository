using System;
using System.Collections.Generic;

namespace _09.UserLogs
{
    class UserLogs
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> userLogs
                = new SortedDictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input.Split(' ');

                string ip = inputArgs[0].Split('=')[1];
                string user = inputArgs[2].Split('=')[1];

                if (!userLogs.ContainsKey(user))
                {
                    userLogs.Add(user, new Dictionary<string, int>());
                }

                if (!userLogs[user].ContainsKey(ip))
                {
                    userLogs[user].Add(ip, 0);
                }

                userLogs[user][ip]++;
            }

            foreach (var user in userLogs.Keys)
            {
                Console.WriteLine(user + ":");
                int ipCount = userLogs[user].Count;
                foreach (var pair in userLogs[user])
                {
                    ipCount--;
                    if (ipCount != 0)
                    {
                        Console.Write($"{pair.Key} => {pair.Value}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{pair.Key} => {pair.Value}.");
                    }
                }
            }
        }   
    }
}