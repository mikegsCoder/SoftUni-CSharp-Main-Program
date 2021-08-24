using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForVacation = double.Parse(Console.ReadLine());
            double existingMoney = double.Parse(Console.ReadLine());

            int dayCounter = 0;
            int spendingCounter = 0;
            string action = "";
            double ammount = 0.0;

            while (existingMoney < moneyForVacation)
            {
                action = Console.ReadLine();
                ammount = double.Parse(Console.ReadLine());
                dayCounter += 1;

                if (action == "spend")
                {
                    spendingCounter += 1;
                    existingMoney -= ammount;

                    if (existingMoney < 0) existingMoney = 0;

                    if (spendingCounter == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(dayCounter);
                        break;
                    }
                }

                if (action == "save")
                {
                    spendingCounter = 0;
                    existingMoney += ammount;
                }
            }

            if (spendingCounter < 5)
            {
                Console.WriteLine($"You saved the money for {dayCounter} days.");
            }
        }
    }
}
