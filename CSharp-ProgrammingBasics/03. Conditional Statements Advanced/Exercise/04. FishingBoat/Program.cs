using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double boatPrice = 0.0;

            switch (season)
            {
                case "Spring":
                    if (fishermans <= 6) boatPrice = 3000 * 0.9;
                    if (fishermans >= 7 && fishermans <= 11) boatPrice = 3000 * 0.85;
                    if (fishermans >= 12) boatPrice = 3000 * 0.75;
                    if (fishermans % 2 == 0) boatPrice = boatPrice * 0.95;
                    break;
                case "Summer":
                    if (fishermans <= 6) boatPrice = 4200 * 0.9;
                    if (fishermans >= 7 && fishermans <= 11) boatPrice = 4200 * 0.85;
                    if (fishermans >= 12) boatPrice = 4200 * 0.75;
                    if (fishermans % 2 == 0) boatPrice = boatPrice * 0.95;
                    break;
                case "Autumn":
                    if (fishermans <= 6) boatPrice = 4200 * 0.9;
                    if (fishermans >= 7 && fishermans <= 11) boatPrice = 4200 * 0.85;
                    if (fishermans >= 12) boatPrice = 4200 * 0.75;
                    break;
                case "Winter":
                    if (fishermans <= 6) boatPrice = 2600 * 0.9;
                    if (fishermans >= 7 && fishermans <= 11) boatPrice = 2600 * 0.85;
                    if (fishermans >= 12) boatPrice = 2600 * 0.75;
                    if (fishermans % 2 == 0) boatPrice = boatPrice * 0.95;
                    break;
            }

            if (budget >= boatPrice) Console.WriteLine($"Yes! You have {(budget-boatPrice):f2} leva left.");
            if (boatPrice > budget) Console.WriteLine($"Not enough money! You need {(boatPrice-budget):f2} leva.");
        }
    }
}
