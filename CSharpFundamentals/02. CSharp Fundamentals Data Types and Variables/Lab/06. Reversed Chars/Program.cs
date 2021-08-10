using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new char[3];
            string inputString = "";

            for (int i = 0; i < 3; i++)
            {
                input[i] = Console.ReadKey().KeyChar;
                Console.WriteLine();
                inputString += input[i];
            }
                        
            for (int i = 2; i >= 0; i--)
            {
                Console.Write(inputString[i]+" ");
            }
        }
    }
}
