using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {           
            double vacationPrice = double.Parse(Console.ReadLine());
            int numberOfPuzzles = int.Parse(Console.ReadLine());
            int numberOfPuppets = int.Parse(Console.ReadLine());
            int numberOfBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            double priceOfPuzzle = 2.60;
            double priceOfPuppet = 3;
            double priceOfBear = 4.10;
            double priceOfMinion = 8.20;
            double priceOfTruck = 2;
            double numberOfToys = numberOfPuzzles + numberOfPuppets + numberOfBears + numberOfMinions + numberOfTrucks;
            double income = numberOfPuzzles * priceOfPuzzle + numberOfPuppets * priceOfPuppet + numberOfBears * priceOfBear + numberOfMinions * priceOfMinion + numberOfTrucks * priceOfTruck;
            
            if (numberOfToys < 50)
            {
                double finalIncome = income * 0.9;
                if (finalIncome >= vacationPrice)
                {
                    double moneySurplus = finalIncome - vacationPrice;
                    Console.WriteLine($"Yes! {moneySurplus:F2} lv left.");
                }
                else
                {
                    double moneyLack = vacationPrice - finalIncome;
                    Console.WriteLine($"Not enough money! {moneyLack:F2} lv needed.");
                }
            }
            else
            { 
                double finalIncome = income * 0.75 * 0.9;
                if (finalIncome >= vacationPrice)
                {
                    double moneySurplus = finalIncome - vacationPrice;
                    Console.WriteLine($"Yes! {moneySurplus:F2} lv left.");
                }
                else
                {
                    double moneyLack = vacationPrice - finalIncome;
                    Console.WriteLine($"Not enough money! {moneyLack:F2} lv needed.");
                }
            }
        }
    }
}
