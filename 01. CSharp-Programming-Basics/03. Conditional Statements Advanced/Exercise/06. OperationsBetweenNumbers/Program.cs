using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            string resultType = "";
            double result = 0.0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    if (result % 2 == 0) resultType = "even";
                    if (result % 2 != 0) resultType = "odd";
                    Console.WriteLine($"{num1} + {num2} = {result} - {resultType}");
                    break;
                case "-":
                    result = num1 - num2;
                    if (result % 2 == 0) resultType = "even";
                    if (result % 2 != 0) resultType = "odd";
                    Console.WriteLine($"{num1} - {num2} = {result} - {resultType}");
                    break;
                case "*":
                    result = num1 * num2;
                    if (result % 2 == 0) resultType = "even";
                    if (result % 2 != 0) resultType = "odd";
                    Console.WriteLine($"{num1} * {num2} = {result} - {resultType}");
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        double n1 = num1;
                        double n2 = num2;
                        result = n1 / n2;
                        Console.WriteLine($"{num1} / {num2} = {result:f2}");
                    }

                    if (num2 == 0) Console.WriteLine($"Cannot divide {num1} by zero");
                    break;
                case "%":
                    if (num2 != 0)
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} % {num2} = {result}");
                    }

                    if (num2 == 0) Console.WriteLine($"Cannot divide {num1} by zero");
                    break;
            }
        }
    }
}
