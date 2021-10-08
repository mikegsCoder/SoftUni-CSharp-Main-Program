using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double ticketPrice = 0.0;

            switch (projectionType)
            {
                case "Premiere":
                    ticketPrice = 12.00;
                    break;
                case "Normal":
                    ticketPrice = 7.50;
                    break;
                case "Discount":
                    ticketPrice = 5.00;
                    break;
            }

            Console.WriteLine($"{rows*colums*ticketPrice:f2}"," leva");
        }
    }
}
