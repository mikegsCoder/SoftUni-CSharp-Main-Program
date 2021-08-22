using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = 0.0;

            switch (flowers)
            {
                case "Roses":
                    if (flowersCount <= 80) flowerPrice = 5.0;
                    else flowerPrice = 5.0 * 0.9;
                    break;
                case "Dahlias":
                    if (flowersCount <= 90) flowerPrice = 3.80;
                    else flowerPrice = 3.80 * 0.85;
                    break;
                case "Tulips":
                    if (flowersCount <= 80) flowerPrice = 2.80;
                    else flowerPrice = 2.80 * 0.85;
                    break;
                case "Narcissus":
                    if (flowersCount < 120) flowerPrice = 3 * 1.15;
                    else flowerPrice = 3;
                    break;
                case "Gladiolus":
                    if (flowersCount < 80) flowerPrice = 2.50 * 1.20;
                    else flowerPrice = 2.50;
                    break;
            }

            if (budget >= flowerPrice * flowersCount) Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowers} and {(budget-(flowerPrice*flowersCount)):f2} leva left.");
            if (budget < flowerPrice * flowersCount) Console.WriteLine($"Not enough money, you need {((flowerPrice * flowersCount)-budget):f2} leva more.");
        }
    }
}
