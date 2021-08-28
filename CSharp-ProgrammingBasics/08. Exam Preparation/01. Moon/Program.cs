using System;

namespace _01.Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            double averageSpeed = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());

            double timeNeeded = Math.Ceiling(768800 / averageSpeed) + 3;
            double fuelNeeded = (fuel * 768800) / 100;

            Console.WriteLine(timeNeeded);
            Console.WriteLine(fuelNeeded);
        }
    }
}
