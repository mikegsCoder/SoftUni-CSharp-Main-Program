using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGrade(grade);
        }
        static void PrintGrade(double grade)
        {
            if (2.00<= grade && grade <=2.99)
            {
                Console.WriteLine("Fail");
            }

            if (3.00 <= grade && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }

            if (3.50 <= grade && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }

            if (4.50 <= grade && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }

            if (5.50 <= grade && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }

    }
}
