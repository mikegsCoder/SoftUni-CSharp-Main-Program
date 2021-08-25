using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= n+1; rows++)
            {
                for (int cols = 0; cols < rows; cols++)
                {
                    if (counter == n+1)
                    {
                        isBigger = true;
                        break;
                    }

                    Console.Write($"{counter} ");
                    counter++;
                }

                if (isBigger)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
