using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();

            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());

                double squareArea = side * side;

                Console.WriteLine("{0:F3}", squareArea);
            }
            else if (figureType == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());

                double rectangleArea = side1 * side2;

                Console.WriteLine("{0:F3}", rectangleArea);

            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());

                double circleArea = Math.PI * radius * radius;

                Console.WriteLine("{0:F3}", circleArea);

            }
            else if (figureType == "triangle")
            { 
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double triangleArea = side * height /2;

                Console.WriteLine("{0:F3}", triangleArea);
            }
        }
    }
}
