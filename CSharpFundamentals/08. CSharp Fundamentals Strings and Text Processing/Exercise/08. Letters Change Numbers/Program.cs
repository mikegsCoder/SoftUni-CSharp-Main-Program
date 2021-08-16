using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            double result = 0.0;

            foreach (var current in input)
            {
                result += StringCalculator(current);
            }

            Console.WriteLine($"{result:f2}");
        }
        static double StringCalculator(string input)
        {            
            double stringValue = 0.0;

            char firstLetter = input[0];
            char lastLetter = input[input.Length - 1];
            double firstLetterIndex = char.ToUpper(firstLetter) - 64;
            double lastLetterIndex = char.ToUpper(lastLetter) - 64;
            double number = double.Parse(input.Substring(1, input.Length - 2));

            if (Char.IsUpper(firstLetter))
            {
                stringValue = number / firstLetterIndex;
            }
            else
            {
                stringValue = number * firstLetterIndex;
            }

            if (Char.IsUpper(lastLetter))
            {
                stringValue -= lastLetterIndex;
            }
            else
            {
                stringValue += lastLetterIndex;
            }

            return stringValue;
        }
    }
}
