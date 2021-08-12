using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(PowerCalculator(number, power));
        }

        static double PowerCalculator(double number, int power)
        {
            return Math.Pow(number, power);
        }
    }
}
