using System;

namespace _04._CSharp_Fundamentals_Methods_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSmallestNum(num1, num2, num3));
        }
        static int GetSmallestNum(int num1, int num2, int num3)
        {
            return Math.Min(Math.Min(num1, num2), num3);
        }
    }
}
