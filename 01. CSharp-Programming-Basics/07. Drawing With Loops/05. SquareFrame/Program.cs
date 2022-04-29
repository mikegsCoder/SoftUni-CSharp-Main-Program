using System;

namespace SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    Console.Write("+");

                    for (int j = 0; j < n-2; j++)
                    {
                        Console.Write(" -");
                    }

                    Console.Write(" +");
                    Console.WriteLine();
                }

                if (i != 1 && i != n)
                {
                    Console.Write("|");

                    for (int k = 0; k < n-2; k++)
                    {
                        Console.Write(" -");
                    }

                    Console.Write(" |");
                    Console.WriteLine();
                }
            }
        }
    }
}
