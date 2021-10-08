using System;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row1 = 1; row1 <= n; row1++)
            {
                Console.Write(new string(' ',n-row1));
                Console.Write("*");

                for (int j = 1; j <= row1-1; j++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }

            for (int row2 = n-1; row2 >= 1; row2--)
            {
                Console.Write(new string(' ', n-row2));
                Console.Write("*");

                for (int j = 1; j <= row2 - 1; j++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }
        }
    }
}
