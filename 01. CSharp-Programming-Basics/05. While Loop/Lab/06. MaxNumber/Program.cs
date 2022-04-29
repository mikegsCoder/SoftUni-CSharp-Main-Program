using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int max = int.MinValue;

            while (input != "Stop")
            {
                int currentInput = int.Parse(input);
                if (currentInput > max) max = currentInput;

                input = Console.ReadLine();
            }

            Console.WriteLine(max);
        }
    }
}
