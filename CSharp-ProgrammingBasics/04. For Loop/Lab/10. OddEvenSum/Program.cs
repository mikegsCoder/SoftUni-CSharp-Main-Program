using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());

                if (i % 2 == 0) evenSum = evenSum + num1;
                if (i % 2 != 0) oddSum = oddSum + num1;
            }

            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }

            if (evenSum != oddSum)
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(evenSum-oddSum)}");
            }
        }
    }
}
