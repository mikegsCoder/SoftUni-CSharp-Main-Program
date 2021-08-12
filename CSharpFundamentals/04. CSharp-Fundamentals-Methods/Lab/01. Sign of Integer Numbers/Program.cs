using System;

namespace _04._CSharp_Fundamentals_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintSign(n);
        }

        static void PrintSign(int n)
        {
            if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }

            if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }

            if (n == 0)
            {
                Console.WriteLine($"The number {n} is zero.");
            }
        }
    }
}
