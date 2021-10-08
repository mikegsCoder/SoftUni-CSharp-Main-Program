using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09._CSharp_Fundamentals_Regular_Expressions_Regex_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();
            double totalPrice = 0.0;
 
            string input = Console.ReadLine();
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    furniture.Add(match.Groups["furniture"].Value);
                    totalPrice += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);                    
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (totalPrice > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
