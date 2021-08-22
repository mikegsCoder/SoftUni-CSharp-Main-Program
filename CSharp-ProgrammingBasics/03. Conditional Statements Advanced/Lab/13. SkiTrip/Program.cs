using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string mark = Console.ReadLine();

            double discount = 0.0;
            double nightPrice = 0.0;

            switch (roomType)
            {
                case "room for one person":
                    nightPrice = 18.00;
                    discount = 0.0;
                    break;
                case "apartment":
                    nightPrice = 25.00;
                    if ((days - 1) < 10) discount = 0.30;                    
                    if ((days-1) >= 10 && (days - 1) <= 15) discount = 0.35;
                    if ((days - 1) > 15) discount = 0.50;
                    break;
                case "president apartment":
                    nightPrice = 35.00;
                    if ((days - 1) < 10) discount = 0.10;
                    if ((days - 1) >= 10 && (days - 1) <= 15) discount = 0.15;
                    if ((days - 1) > 15) discount = 0.20;
                    break;
            }
            switch (mark)
            {
                case "positive":
                    Console.WriteLine($"{(days - 1)*nightPrice*(1-discount)*1.25:f2}");
                    break;
                case "negative":
                    Console.WriteLine($"{(days - 1) * nightPrice * (1 - discount) * 0.90:f2}");
                    break;
            }
        }
    }
}
