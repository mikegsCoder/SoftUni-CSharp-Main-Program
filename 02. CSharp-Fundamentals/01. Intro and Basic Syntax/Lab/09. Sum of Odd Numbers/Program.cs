﻿using System;

namespace _9._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i < 2*n; i+=2)
            {
                Console.WriteLine(i);
                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
