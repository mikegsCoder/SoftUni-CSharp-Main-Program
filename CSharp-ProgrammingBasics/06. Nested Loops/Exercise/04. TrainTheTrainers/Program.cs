using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double markSumGeneral = 0.0;
            int markCounter = 0;

            while (input != "Finish")
            {
                double markSum = 0.0;

                for (int i = 1; i <= n; i++)
                {
                    double currentMark = double.Parse(Console.ReadLine());
                    markSum += currentMark;
                    markCounter++;
                }

                Console.WriteLine($"{input} - {markSum/n:f2}.");

                markSumGeneral += markSum;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {markSumGeneral/markCounter:f2}.");
        }
    }
}
