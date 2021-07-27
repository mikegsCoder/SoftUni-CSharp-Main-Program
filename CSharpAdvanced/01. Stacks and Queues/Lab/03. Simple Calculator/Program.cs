using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> expression = new Stack<string>(input.Reverse());

            while (expression.Count > 1)
            {
                int leftNumber = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int rightNumber = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    expression.Push((leftNumber + rightNumber).ToString());
                }
                else if (sign == "-")
                {
                    expression.Push((leftNumber - rightNumber).ToString());
                }
            }

            Console.WriteLine(expression.Pop());
        }
    }
}
