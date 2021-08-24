using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badMarks = int.Parse(Console.ReadLine());
            string taskName = Console.ReadLine();
            double currentMark = 0.0;

            int badCounter = 0;
            int goodCounter = 0;
            double markSum = 0.0;
            string lastProblem = "";

            while (taskName != "Enough")
            {
                currentMark = double.Parse(Console.ReadLine());

                if (currentMark <= 4)
                {
                    badCounter += 1;

                    if (badCounter == badMarks)
                    {
                        Console.WriteLine($"You need a break, {badCounter} poor grades.");
                        break;
                    }
                }

                if (currentMark > 4)
                {
                    goodCounter += 1;
                }

                markSum += currentMark;
                lastProblem = taskName;
                taskName = Console.ReadLine();
            }

            if (badCounter < badMarks)
            {
                Console.WriteLine($"Average score: {(markSum / (badCounter + goodCounter)):f2}");
                Console.WriteLine($"Number of problems: {badCounter + goodCounter}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
