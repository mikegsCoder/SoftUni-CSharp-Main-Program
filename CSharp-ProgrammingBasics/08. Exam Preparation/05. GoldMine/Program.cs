using System;

namespace Test_24._10._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());

            double currentLocationGoldYield = 0.0;

            for (int i = 1; i <= locations; i++)
            {
                double expectedGoldYield = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());

                for (int j = 1; j <= days; j++)
                {
                    double currentDayGoldYield = double.Parse(Console.ReadLine());
                    currentLocationGoldYield += currentDayGoldYield;
                }

                if(currentLocationGoldYield/days >= expectedGoldYield)
                {
                    Console.WriteLine($"Good job! Average gold per day: {currentLocationGoldYield / days:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {expectedGoldYield-currentLocationGoldYield/days:f2} gold.");
                }

                currentLocationGoldYield = 0.0;
            }
        }
    }
}
