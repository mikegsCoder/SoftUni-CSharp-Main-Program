using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int min = int.MaxValue;

            while (input != "Stop")
            {
                int currentInput = int.Parse(input);
                if (currentInput < min) min = currentInput;

                input = Console.ReadLine();
            }

            Console.WriteLine(min);
        }
    }
}
