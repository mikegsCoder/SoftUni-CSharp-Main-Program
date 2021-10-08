using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsInfo = 
                new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] currentInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = currentInput[0];
                string product = currentInput[1];
                double price = double.Parse(currentInput[2]);

                if (!shopsInfo.ContainsKey(shop))
                {
                    shopsInfo.Add(shop, new Dictionary<string, double>());
                    shopsInfo[shop].Add(product, price);
                }
                else if (!shopsInfo[shop].ContainsKey(product))
                {
                    shopsInfo[shop].Add(product, price);
                }
                else if (shopsInfo[shop].ContainsKey(product))
                {
                    shopsInfo[shop][product] = price;
                }
            }

            foreach (var shop in shopsInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
