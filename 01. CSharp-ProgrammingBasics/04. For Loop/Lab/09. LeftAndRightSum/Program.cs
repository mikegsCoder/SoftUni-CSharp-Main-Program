using System;

namespace _09.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 1; i <= 2*n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());

                if (i <= n) leftSum = leftSum + num1; 
                if (i > n) rightSum = rightSum + num1;
            }

            if (leftSum == rightSum) Console.WriteLine($"Yes, sum = {leftSum}");
            if (leftSum != rightSum) Console.WriteLine($"No, diff = {Math.Abs(leftSum-rightSum)}");
        }
    }
}
