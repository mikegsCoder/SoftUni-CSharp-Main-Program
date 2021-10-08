using System;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                       
            int leftRight = 0;
            int mid = 0;
            int k = 0;

            if (n % 2 != 0)
            {
                k = n;
            }
            else
            {
                k = n - 1;
            }

            leftRight = (int)((n - 1) / 2);

            for (int i = 1; i < k; i++)
            {
                mid = (int)(n - 2 * leftRight - 2);
                if (leftRight > 0)
                {
                    Console.Write(new string('-', leftRight));
                    if (mid > 0)
                    {
                        Console.Write("*");
                        Console.Write(new string('-', mid));
                        Console.Write("*");
                    }
                    else
                    {
                        if ((i == 1 || i==k-1) && n % 2 != 0)
                        {
                            Console.Write("*");
                        }
                        if ((i == 1 || i == k-1) && n % 2 == 0)
                        {
                            Console.Write("**");
                        }
                    }

                    Console.Write(new string('-', leftRight));
                }

                if (i < k / 2)
                {
                    leftRight--;
                }

                if (i == k / 2)
                {
                    Console.WriteLine();
                    Console.Write("*");
                    Console.Write(new string('-', n - 2));
                    Console.Write("*");
                    leftRight = 0;
                }

                if (i >= k / 2)
                {
                    leftRight++;
                }
                Console.WriteLine();
            }

            if (n == 1)
            {
                Console.WriteLine("*");
            }

            if (n == 2)
            {
                Console.WriteLine("**");
            }
        }
    }
}
