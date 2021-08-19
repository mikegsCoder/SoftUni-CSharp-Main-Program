using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsInfo =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentsInfo[continent].ContainsKey(country))
                {
                    continentsInfo[continent].Add(country, new List<string>());
                }

                continentsInfo[continent][country].Add(city);
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($" {country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
