using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int volume = width * heigth;
            int counter = 0;

            while (input != "STOP")
            {
                int currentInput = int.Parse(input);
                counter += currentInput;

                if (counter >= volume)
                {
                    Console.WriteLine($"No more cake left! You need {counter-volume} pieces more.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (counter <= volume)
            {
                Console.WriteLine($"{volume-counter} pieces are left.");
            }
        }
    }
}
