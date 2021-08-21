using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {            
            int days = int.Parse(Console.ReadLine());
            int confectioners = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesInkomePerDay = cakes * 45;
            double wafflesInkomePerDay = waffles * 5.80;
            double pancakesInkomePerDay = pancakes * 3.20;
            double inkomePerDay = (cakesInkomePerDay + wafflesInkomePerDay + pancakesInkomePerDay)* confectioners;
            double campaignIncome = inkomePerDay * days;
            double finalIncome = campaignIncome * 7 / 8;

            Console.WriteLine(finalIncome);
        }
    }
}
