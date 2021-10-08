using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double ammount = double.Parse(Console.ReadLine());

            double price = 0.0;

            if (town == "Sofia")
            {
                if (product == "beer")
                 {
                    price = 1.20;
                 }
                if (product == "coffee")
                 {
                    price = 0.50;
                 }
                if (product == "water")
                 {
                    price = 0.80;
                 }
                if (product == "sweets")
                 {
                    price = 1.45;
                 }
                if (product == "peanuts")
                 {
                    price = 1.60;
                 }
            }
            if (town == "Plovdiv")
            {
                if (product == "beer")
                {
                    price = 1.15;
                }
                if (product == "coffee")
                {
                    price = 0.40;
                }
                if (product == "water")
                {
                    price = 0.70;
                }
                if (product == "sweets")
                {
                    price = 1.30;
                }
                if (product == "peanuts")
                {
                    price = 1.50;
                }
            }
            if (town == "Varna")
            {
                if (product == "beer")
                {
                    price = 1.10;
                }
                if (product == "coffee")
                {
                    price = 0.45;
                }
                if (product == "water")
                {
                    price = 0.70;
                }
                if (product == "sweets")
                {
                    price = 1.35;
                }
                if (product == "peanuts")
                {
                    price = 1.55;
                }
            }

            Console.WriteLine(ammount*price);
        }
    }
}
