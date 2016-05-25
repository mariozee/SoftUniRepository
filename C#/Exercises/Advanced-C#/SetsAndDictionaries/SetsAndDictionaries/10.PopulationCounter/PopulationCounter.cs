using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationData
                = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "report")
            {
                string[] inputArgs = input.Split('|');

                string country = inputArgs[1];
                string city = inputArgs[0];
                int population = int.Parse(inputArgs[2]);

                if (!populationData.ContainsKey(country))
                {
                    populationData.Add(country, new Dictionary<string, long>());
                }

                if (!populationData[country].ContainsKey(city))
                {
                    populationData[country].Add(city, 0);
                }

                populationData[country][city] += population;
            }

            var sortedCoutries = populationData.OrderByDescending(x => x.Value.Values.Sum(p => p));

            foreach (var coutryData in sortedCoutries)
            {
                Console.WriteLine(String.Format("{0} (total population: {1})", coutryData.Key, 
                    populationData[coutryData.Key].Values.Sum(p => p)));
                var sortedCities = populationData[coutryData.Key].OrderByDescending(c => c.Value);
                foreach (var cityData in sortedCities)
                {
                    Console.WriteLine($"=>{cityData.Key}: {cityData.Value}");
                }
            }
        }
    }
}