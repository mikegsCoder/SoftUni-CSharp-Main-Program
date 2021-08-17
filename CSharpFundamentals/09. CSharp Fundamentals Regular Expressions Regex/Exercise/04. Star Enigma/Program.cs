using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string pattern = @"[SsTtAaRr]";

                string input = Console.ReadLine();

                var matches = Regex.Matches(input, pattern);
                int count = matches.Count;
                string decryptedMessage = string.Empty;

                foreach (var character in input)
                {
                    decryptedMessage += (char)((int)character - count);
                }

                string regex = @"^[^@,\-!:>]*@(?<planet>[A-Za-z]+)[^@,\-!:>]*:[^@,\-!:>]*?(?<populationCount>\d+)[^@,\-!:>]*![^@,\-!:>]*(?<attackType>[AD])![^@,\-!:>]*->(?<soldierCount>\d+)[^@,\-!:>]*$";
                var decryptedMatches = Regex.Match(decryptedMessage, regex);

                if (decryptedMatches.Groups["attackType"].Value == "A" && decryptedMatches.Groups["planet"].Value != "" )
                {
                    attackedPlanets.Add(decryptedMatches.Groups["planet"].Value);
                }
                else if ( decryptedMatches.Groups["attackType"].Value == "D" && decryptedMatches.Groups["planet"].Value != "" )
                {
                    destroyedPlanets.Add(decryptedMatches.Groups["planet"].Value);
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();
                        
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                foreach (var planet in attackedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            if (destroyedPlanets.Count > 0)
            {
                foreach (var planet in destroyedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
