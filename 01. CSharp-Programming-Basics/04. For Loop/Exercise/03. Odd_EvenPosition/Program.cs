using System;

namespace _03.Odd_EvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num1 = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum = oddSum + num1;
                    if (num1 > oddMax) oddMax = num1;
                    if (num1 < oddMin) oddMin = num1;
                }

                if (i % 2 == 0)
                {
                    evenSum = evenSum + num1;
                    if (num1 > evenMax) evenMax = num1;
                    if (num1 < evenMin) evenMin = num1;
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (oddMin != double.MaxValue && oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenMin != double.MaxValue && evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else
            {
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
