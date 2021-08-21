using System;

namespace SquareArea
{
    class Program
    {
        static void Main(string[] args)
        {            
            int side = int.Parse(Console.ReadLine());

            int squareArea = side * side;

            Console.WriteLine(squareArea);
        }
    }
}
