using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, height);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
