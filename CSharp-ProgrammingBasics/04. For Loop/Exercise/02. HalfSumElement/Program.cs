using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxElement = 0;
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                if (num1 > maxElement) maxElement = num1;
                sum = sum + num1;
            }

            sum = sum - maxElement;

            if (maxElement == sum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }

            if (maxElement != sum)
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum-maxElement)}");
            }
        }
    }
}
