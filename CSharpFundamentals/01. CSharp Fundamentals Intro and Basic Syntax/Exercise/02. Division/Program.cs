using System;

namespace _2._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int division = 0;

            if (n % 2 == 0) division = 2;
            if (n % 3 == 0) division = 3;
            if (n % 6 == 0) division = 6;
            if (n % 7 == 0) division = 7;
            if (n % 10 == 0) division = 10;

            if (division > 0)
            {
                Console.WriteLine($"The number is divisible by {division}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
