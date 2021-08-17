using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAndKms = new Dictionary<string, int>();

            string[] contestants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string namePattern = "[A-Za-z]";
            string digitsPattern = "[0-9]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var nameMatch = Regex.Matches(input, namePattern);
                var kmMatch = Regex.Matches(input, digitsPattern);

                var name = string.Concat(nameMatch);
                var sumOfKm = kmMatch.Select(x => int.Parse(x.Value)).Sum();

                if (contestants.Contains(name))
                {
                    if (namesAndKms.ContainsKey(name))
                    {
                        namesAndKms[name] += sumOfKm;
                    }
                    else
                    {
                        namesAndKms.Add(name, sumOfKm);
                    }
                }

                input = Console.ReadLine();
            }

            var sorted = namesAndKms.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
                        
            if (namesAndKms.Count > 0)
            {
                Console.WriteLine($"1st place: {sorted[0]}");
            }

            if (namesAndKms.Count > 1)
            {
                Console.WriteLine($"2nd place: {sorted[1]}");
            }

            if (namesAndKms.Count > 2)
            {
                Console.WriteLine($"3rd place: {sorted[2]}");
            }
        }
    }
}
