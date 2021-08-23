using System;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());

                if (num1 % 2 ==0) count1++;
                if (num1 % 3 ==0) count2++;
                if (num1 % 4 == 0) count3++;
            }

            double p1 = (count1 / n) * 100;
            double p2 = (count2 / n) * 100;
            double p3 = (count3 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
