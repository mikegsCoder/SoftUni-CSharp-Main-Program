using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double currentIncrease = 0.0;
            double bancAccount = 0.0;

            while (input != "NoMoreMoney")
            {
                currentIncrease = double.Parse(input);

                if (currentIncrease < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                bancAccount += currentIncrease;

                Console.WriteLine($"Increase: {currentIncrease:f2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {bancAccount:f2}");
        }
    }
}
