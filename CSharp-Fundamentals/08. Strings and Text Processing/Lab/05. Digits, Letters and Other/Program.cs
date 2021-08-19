using System;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    Console.Write(input[i]);
                }                
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    Console.Write(input[i]);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]) && !Char.IsDigit(input[i]))
                {
                    Console.Write(input[i]);
                }
            }
        }
    }
}
