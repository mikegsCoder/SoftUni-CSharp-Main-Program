using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
                        
            decimal result = FactorialCalculator(num1) / FactorialCalculator(num2);
            Console.WriteLine($"{result:f2}");
        }

        static decimal FactorialCalculator(int n)
        {
            decimal factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
