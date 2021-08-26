using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _11._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> destinations = new List<string>();

            string pattern = @"\=[A-Z][A-Za-z]{2,}\=|\/[A-Z][A-Za-z]{2,}\/";

            string input = Console.ReadLine();

            var destinationsMatch = Regex.Matches(input, pattern);

            foreach (Match destination in destinationsMatch)
            {
                string currentDestination = destination.Value.Substring(1, destination.Value.Length - 2);
                destinations.Add(currentDestination);
            }

            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ",destinations));

            int travelPoints = 0;

            foreach (var destination in destinations)
            {
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
