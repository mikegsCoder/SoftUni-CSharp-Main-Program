using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length, width, height, volume = 0;

            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());

            volume = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
