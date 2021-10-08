using System;

namespace _02._CSharp_Fundamentals_Data_Types_and_Variables_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int result = ((firstNum + secondNum) / thirdNum) * fourthNum;
            Console.WriteLine(result);
        }
    }
}
