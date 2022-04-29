using System;

namespace _04.EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());

            for (int pow = 0; pow <= power; pow+=2)
            {
                double result = Math.Pow(2, pow);
                Console.WriteLine(result);
            }
        }
    }
}
