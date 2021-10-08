﻿using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                string currentNum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    if (j % 2 == 0) oddSum += currentDigit;
                    if (j % 2 != 0) evenSum += currentDigit;
                }

                if (oddSum == evenSum) Console.Write($"{i} ");
            }
        }
    }
}
