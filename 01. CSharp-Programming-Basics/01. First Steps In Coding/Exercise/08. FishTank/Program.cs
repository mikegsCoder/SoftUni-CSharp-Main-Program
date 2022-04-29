using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {            
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = length * width * heigth * 0.001;
            double finalResult = volume * (1 - percent * 0.01);

            Console.WriteLine(finalResult);
        }
    }
}
