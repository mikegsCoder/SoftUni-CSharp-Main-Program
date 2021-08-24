using System;
using System.Transactions;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());

            int freeSpace = width * length * hight;

            string input = Console.ReadLine();

            while (input != "Done")
            {
                int currentInput = int.Parse(input);
                freeSpace = freeSpace - currentInput;

                if (freeSpace < 0)
                {
                    Console.WriteLine($"No more free space! You need {-freeSpace} Cubic meters more.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (freeSpace >= 0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
