using System;

namespace _6._Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string numStr = num.ToString();
            int length = numStr.Length - 1;

            double currentNum = 0;
            double factorial = 0;
            double factorialSum = 0;

            for (int i = 0; i <= length; i++)
            {
                currentNum = Char.GetNumericValue(numStr[i]);

                factorial = currentNum;
                for (double j = currentNum - 1; j >= 1; j--)
                {
                    factorial = factorial * j;
                }

                factorialSum += factorial;
            }

            if (factorialSum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
