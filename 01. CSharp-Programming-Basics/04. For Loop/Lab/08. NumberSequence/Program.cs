using System;

namespace _08.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int min = 0;
            int max = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    min = num1;
                    max = num1;
                }

                if (num1 < min) min = num1;
                if (num1 > max) max = num1;
            }

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
