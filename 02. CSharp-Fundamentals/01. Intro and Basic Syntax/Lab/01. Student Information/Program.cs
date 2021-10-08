using System;

namespace _01._CSharp_Fundamentals_Intro_and_Basic_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}, Age: {1}, Grade: {2:f2}",name,age,grade);
        }
    }
}
