using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string accomodation = "";
            double price = 0.0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    price = 0.30;
                }
                if (season == "winter")
                {
                    accomodation = "Hotel";
                    price = 0.70;
                }
            }

            if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    price = 0.40;
                }
                if (season == "winter")
                {
                    accomodation = "Hotel";
                    price = 0.80;
                }
            }

            if (budget > 1000)
            {
                destination = "Europe";
                price = 0.90;
                accomodation = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {(budget*price):f2}");
        }
    }
}
