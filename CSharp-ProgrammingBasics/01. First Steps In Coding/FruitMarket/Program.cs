using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {            
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaAmmount = double.Parse(Console.ReadLine());
            double orangeAmmount = double.Parse(Console.ReadLine());
            double raspberryAmmount = double.Parse(Console.ReadLine());
            double strawberryAmmount = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice * 0.6;
            double bananaPrice = raspberryPrice * 0.2;
            double moneyForRaspberry = raspberryAmmount * raspberryPrice;
            double moneyForStrawberry = strawberryAmmount * strawberryPrice;
            double moneyForOrange = orangeAmmount * orangePrice;
            double moneyForBanana = bananaAmmount * bananaPrice;
            double finalPrice = moneyForRaspberry + moneyForStrawberry + moneyForOrange + moneyForBanana;
           
            Console.WriteLine(finalPrice);
        }
    }
}
