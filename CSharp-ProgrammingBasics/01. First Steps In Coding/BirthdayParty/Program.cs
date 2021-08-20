using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double hallPrice = double.Parse(Console.ReadLine());
            double cakePrice = hallPrice * 0.2;
            double drinksPrice = cakePrice * 0.55;
            double animatorPrice = hallPrice / 3;
            double finalPrice = hallPrice + cakePrice + drinksPrice + animatorPrice;

            Console.WriteLine(finalPrice);
        }
    }
}
