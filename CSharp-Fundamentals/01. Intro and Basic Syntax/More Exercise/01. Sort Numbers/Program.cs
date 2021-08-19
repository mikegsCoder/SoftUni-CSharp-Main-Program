using System;

namespace _01._CSharp_Fundamentals_Intro_and_Basic_Syntax_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int maxNum = Math.Max(num1, num2);
            maxNum = Math.Max(maxNum, num3);

            int minNum = Math.Min(num1, num2);
            minNum = Math.Min(minNum, num3);

            int midNum = 0;

            if (num1 != num2 && num1 != num3 && num2 != num3)
            {
                if (num1 != maxNum && num1 != minNum) midNum = num1;
                if (num2 != maxNum && num2 != minNum) midNum = num2;
                if (num3 != maxNum && num3 != minNum) midNum = num3;
            }
            else
            {
                if (num1 <= maxNum && num1 >= minNum) midNum = num1;
                if (num2 <= maxNum && num2 >= minNum) midNum = num2;
                if (num3 <= maxNum && num3 >= minNum) midNum = num3;
            }

            Console.WriteLine(maxNum);
            Console.WriteLine(midNum);
            Console.WriteLine(minNum);
        }
    }
}
