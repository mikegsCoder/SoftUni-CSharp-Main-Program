using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double ammount = double.Parse(Console.ReadLine());

            int workingDay = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    workingDay = 1;
                    break;
                case "Saturday":
                case "Sunday":
                    workingDay = 0;
                    break;
                default:
                    workingDay = 3;
                    break;
            }

            if (workingDay == 1 && fruit == "banana") Console.WriteLine($"{ammount*2.50:f2}");
            if (workingDay == 1 && fruit == "apple") Console.WriteLine($"{ammount*1.20:f2}");
            if (workingDay == 1 && fruit == "orange") Console.WriteLine($"{ammount*0.85:f2}");
            if (workingDay == 1 && fruit == "grapefruit") Console.WriteLine($"{ammount*1.45:f2}");
            if (workingDay == 1 && fruit == "kiwi") Console.WriteLine($"{ammount*2.70:f2}");
            if (workingDay == 1 && fruit == "pineapple") Console.WriteLine($"{ammount*5.50:f2}");
            if (workingDay == 1 && fruit == "grapes") Console.WriteLine($"{ammount*3.85:f2}");
            
            if (workingDay == 0 && fruit == "banana") Console.WriteLine($"{ammount * 2.70:f2}");
            if (workingDay == 0 && fruit == "apple") Console.WriteLine($"{ammount * 1.25:f2}");
            if (workingDay == 0 && fruit == "orange") Console.WriteLine($"{ammount * 0.90:f2}");
            if (workingDay == 0 && fruit == "grapefruit") Console.WriteLine($"{ammount * 1.60:f2}");
            if (workingDay == 0 && fruit == "kiwi") Console.WriteLine($"{ammount * 3.00:f2}");
            if (workingDay == 0 && fruit == "pineapple") Console.WriteLine($"{ammount * 5.60:f2}");
            if (workingDay == 0 && fruit == "grapes") Console.WriteLine($"{ammount * 4.20:f2}");

            if (workingDay == 3 || (fruit != "banana" && fruit != "apple" &&  fruit != "orange" && fruit != "grapefruit" && fruit != "kiwi" && fruit != "pineapple" && fruit != "grapes")) 
                Console.WriteLine("error");
        }
    }
}
