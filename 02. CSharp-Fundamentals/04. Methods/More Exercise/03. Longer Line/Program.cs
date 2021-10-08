using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            if (Linelength(x1, y1, x2, y2) >= Linelength(x3, y3, x4, y4))
            {
                ClosestToCenter(x1, y1, x2, y2);
            }
            else
            {
                ClosestToCenter(x3, y3, x4, y4);
            }
        }

        static void ClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distance2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (distance1 <= distance2)
            {
                Console.WriteLine("(" + x1 + ", " + y1 + ")"+ "(" + x2 + ", " + y2 + ")");
            }
            else
            {
                Console.WriteLine("(" + x2 + ", " + y2 + ")" + "(" + x1 + ", " + y1 + ")");
            }
        }

        static double Linelength(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return lineLength;
        }
    }
}
