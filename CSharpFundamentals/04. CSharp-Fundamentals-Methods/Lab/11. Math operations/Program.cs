using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            Console.WriteLine(Calculator(firstNum,mathOperator,secondNum));
        }

        static double Calculator(double firstNum, char mathOperator, double secondNum)
        {
            double result = 0;
            switch (mathOperator)
            {
                case '+':
                    result = firstNum + secondNum;
                    break;
                case '-':
                    result = firstNum - secondNum;
                    break;
                case '*':
                    result = firstNum * secondNum;
                    break;
                case '/':
                    result = firstNum / secondNum;
                    break;
            }

            return result;
        }
    }
}
