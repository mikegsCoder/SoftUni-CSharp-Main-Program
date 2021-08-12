using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            RectangleArea(width, heigth);
        }

        static void RectangleArea(double width, double heigth)
        {
            double area = width * heigth;
            Console.WriteLine(area);
        }
    }
}
