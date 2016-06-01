using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.SrubskoUnleashed
{
    class SrubskoUnleashed
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> singersData
                = new Dictionary<string, Dictionary<string, long>>();

            string pattern = @"([a-zA-Z\s]+)\s@([a-zA-Z\s]+)\s([0-9]+)\s([0-9]+)";

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                Match match = new Regex(pattern).Match(input);
                if (!match.Success)
                {
                    continue;
                }

                string singer = match.Groups[1].Value;
                string venue = match.Groups[2].Value;
                int ticketPrice = int.Parse(match.Groups[3].Value);
                int ticketCount = int.Parse(match.Groups[4].Value);
                long moneyMake = ticketCount * ticketPrice;

                if (!singersData.ContainsKey(venue))
                {
                    singersData.Add(venue, new Dictionary<string, long>());
                }

                if (!singersData[venue].ContainsKey(singer))
                {
                    singersData[venue].Add(singer, 0);
                }

                singersData[venue][singer] += moneyMake;
            }

            foreach (var venue in singersData.Keys)
            {
                Console.WriteLine(venue);
                var sortedByMoney = singersData[venue].OrderByDescending(m => m.Value);
                foreach (var pair in sortedByMoney)
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}