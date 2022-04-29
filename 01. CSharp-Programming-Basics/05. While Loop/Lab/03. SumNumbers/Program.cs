using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int num1 = 0;

            while (sum < n)
            {
                num1 = int.Parse(Console.ReadLine());
                sum = sum + num1;
            }

            Console.WriteLine(sum);
        }
    }
}
