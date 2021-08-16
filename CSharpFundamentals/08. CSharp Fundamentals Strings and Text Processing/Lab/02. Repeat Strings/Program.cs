using System;

namespace _08._CSharp_Fundamentals_Strings_and_Text_Processing_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    Console.Write(input[i]);
                }
            }
        }
    }
}
