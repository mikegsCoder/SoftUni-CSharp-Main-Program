using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            double saving = 0;
            double minBudget = 0;

            while (destination != "End")
            {
                minBudget = double.Parse(Console.ReadLine());

                while (saving < minBudget)
                {
                    double currentSaving = double.Parse(Console.ReadLine());
                    saving += currentSaving;
                }

                Console.WriteLine($"Going to {destination}!");

                saving = 0;
                destination = Console.ReadLine();
            }
        }
    }
}
