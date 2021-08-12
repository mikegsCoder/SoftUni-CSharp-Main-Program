using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacters(input);
        }

        static void MiddleCharacters(string input)
        {
            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[(input.Length - 1) / 2]);
            }
            else
            {
                Console.WriteLine($"{input[(input.Length / 2)-1]}{input[input.Length / 2]}");
            }
        }
    }
}
