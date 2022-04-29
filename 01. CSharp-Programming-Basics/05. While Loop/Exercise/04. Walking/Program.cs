using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepCounter = 0;
            string input = Console.ReadLine();

            while (input != "Going home")
            {
                int currentInput = int.Parse(input);
                stepCounter += currentInput;

                if (stepCounter >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepCounter - 10000} steps over the goal!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Going home")
            {
                int homeSteps = int.Parse(Console.ReadLine());
                stepCounter += homeSteps;

                if (stepCounter >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepCounter - 10000} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{10000-stepCounter} more steps to reach goal.");
                }
            }
        }
    }
}
