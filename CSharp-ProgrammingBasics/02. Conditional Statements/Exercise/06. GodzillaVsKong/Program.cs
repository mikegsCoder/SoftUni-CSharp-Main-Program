using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int actors = int.Parse(Console.ReadLine());
            double dressPrice = double.Parse(Console.ReadLine());

            double decorationPrice = budget * 0.1;
            double finalDressPrice = dressPrice * actors;

            if (actors >= 150) finalDressPrice = finalDressPrice * 0.9;

            double expense = decorationPrice + finalDressPrice;

            if (expense > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(expense - budget):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - expense):f2} leva left.");
            }
        }
    }
}
