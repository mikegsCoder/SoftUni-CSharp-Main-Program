using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);

            Console.WriteLine(Multiplication(CalculateOddSum(n), CalculateEvenSum(n)));
        }

        static int CalculateOddSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                if ((n % 10)%2 != 0)
                {
                    sum += n % 10;
                }
                n = n / 10;
            }
            return sum;
        }

        static int CalculateEvenSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                if ((n % 10) % 2 == 0)
                {
                    sum += n % 10;
                }
                n = n / 10;
            }
            return sum;
        }

        static int Multiplication (int a, int b)
        {
            return a * b;
        }
    }
}
