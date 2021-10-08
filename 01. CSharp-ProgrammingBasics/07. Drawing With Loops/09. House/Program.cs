using System;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());

            int n = 0;
            int l = 0;
            int stars = 0;

            if (k % 2 != 0)
            {
                n = (k + 1) / 2;
                l = (k - 1) / 2;
            }
            else
            {
                n = k / 2;
                l = k / 2;
            }

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 && k % 2 != 0)
                {
                    stars = 1;
                    Console.Write(new string('-', n - 1));
                    Console.Write(new string('*', stars));
                    Console.Write(new string('-', n - 1));
                }

                if (i == 1 && k % 2 == 0)
                {
                    stars = 2;
                    Console.Write(new string('-', n - 1));
                    Console.Write(new string('*', stars));
                    Console.Write(new string('-', n - 1));
                }

                if (i > 1)
                {
                    stars += 2;
                    if (n - i == 0)
                    {
                        Console.Write(new string('*', stars));
                    }
                    else
                    {
                        Console.Write(new string('-', n - i));
                        Console.Write(new string('*', stars));
                        Console.Write(new string('-', n - i));
                    }
                }

                Console.WriteLine();
            }

            for (int j = 1; j <= l; j++)
            {
                Console.Write("|");
                Console.Write(new string('*', k - 2));
                Console.Write("|");
                Console.WriteLine();
            }
        }
    }
}
