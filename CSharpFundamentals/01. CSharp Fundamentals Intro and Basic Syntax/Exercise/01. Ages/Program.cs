using System;

namespace _01._CSharp_Fundamentals_Intro_and_Basic_Syntax_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            if (0 <= age && age <= 2) Console.WriteLine("baby");
            if (3 <= age && age <= 13) Console.WriteLine("child");
            if (14 <= age && age <= 19) Console.WriteLine("teenager");
            if (20 <= age && age <= 65) Console.WriteLine("adult");
            if (66 <= age) Console.WriteLine("elder");
        }
    }
}
