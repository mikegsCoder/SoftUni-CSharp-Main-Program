using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<string> products = new List<string>();
            List<double> price = new List<double>();

            string pattern = @"^[^|$%\.]*%(?<name>[A-z]{1}[a-z]+)%[^|$%\.]*<(?<product>\w+)>[^|$%\.]*\|(?<count>\d+)\|[^|$%\.]*?(?<price>\d+(?:\.\d+)?)\$";

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                var match = Regex.Match(input, pattern);
                if (match.Groups["name"].Value != "" && match.Groups["product"].Value != "" && int.Parse(match.Groups["count"].Value) > 0 && double.Parse(match.Groups["price"].Value) > 0)
                {
                    names.Add(match.Groups["name"].Value);
                    products.Add(match.Groups["product"].Value);
                    price.Add((int.Parse(match.Groups["count"].Value)) * (double.Parse(match.Groups["price"].Value)));
                }
            }
                        
            double totalIncome = 0.0;

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{names[i]}: {products[i]} - {price[i]:f2}");
                totalIncome += price[i];
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
