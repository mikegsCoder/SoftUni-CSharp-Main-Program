using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int filledVolume = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());
                if (filledVolume + currentInput > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    filledVolume += currentInput;
                }
            }

            Console.WriteLine(filledVolume);
        }
    }
}
