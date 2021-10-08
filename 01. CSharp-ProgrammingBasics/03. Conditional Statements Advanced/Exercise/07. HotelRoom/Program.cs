using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double appartmentPrice = 0.0;

            if (month == "May" || month == "October")
            {
                if (nights <= 7) studioPrice = 50.0;
                if (nights > 7 && nights <= 14) studioPrice = 50.0 * 0.95;
                if (nights > 14) studioPrice = 50.0 * 0.70;
                if (nights <= 14) appartmentPrice = 65.0;
                if (nights > 14) appartmentPrice = 65.0 * 0.9;
            }

            if (month == "June" || month == "September")
            {
                if (nights <= 14)
                { 
                    studioPrice = 75.20;
                    appartmentPrice = 68.70;
                }
                if (nights > 14)
                { 
                    studioPrice = 75.20 * 0.80;
                    appartmentPrice = 68.70 * 0.9;
                }
            }

            if (month == "July" || month == "August")
            {
                studioPrice = 76.0;
                if (nights <= 14)
                {
                    appartmentPrice = 77.0;
                }
                if (nights > 14)
                {
                    appartmentPrice = 77.0 * 0.9;
                }
            }

            Console.WriteLine($"Apartment: {(nights*appartmentPrice):f2} lv.");
            Console.WriteLine($"Studio: {(nights * studioPrice):f2} lv.");
        }
    }
}
