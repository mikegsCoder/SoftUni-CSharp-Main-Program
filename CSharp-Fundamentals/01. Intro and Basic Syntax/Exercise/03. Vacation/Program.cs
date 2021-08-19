using System;

namespace _3._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            switch (dayOfWeek)
            {
                case "Friday":
                    if (groupType == "Students") price = 8.45;
                    if (groupType == "Business") price = 10.90;
                    if (groupType == "Regular") price = 15.00;
                    break;
                case "Saturday":
                    if (groupType == "Students") price = 9.80;
                    if (groupType == "Business") price = 15.60;
                    if (groupType == "Regular") price = 20.00;
                    break;
                case "Sunday":
                    if (groupType == "Students") price = 10.46;
                    if (groupType == "Business") price = 16.00;
                    if (groupType == "Regular") price = 22.50;
                    break;
            }

            switch (groupType)
            {
                case "Students":
                    if (peopleCount >= 30) price = price * 0.85;
                    break;
                case "Business":
                    if (peopleCount >= 100) peopleCount -= 10;
                    break;
                case "Regular":
                    if (10 <= peopleCount && peopleCount <= 20) price = price * 0.95;
                    break;
            }

            Console.WriteLine($"Total price: {price * peopleCount:f2}");
        }
    }
}
