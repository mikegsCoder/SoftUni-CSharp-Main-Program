using System;

namespace _08.Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsName = Console.ReadLine();

            double badMark = 0;
            double grade = 1;
            double markSum = 0;
            double averageGrade = 0;

            while (grade <= 12)
            {
                double currentMark = double.Parse(Console.ReadLine());

                if (currentMark < 4)
                {
                    badMark += 1;
                    if (badMark == 2) break;
                }

                if (currentMark >= 4)
                {
                    grade += 1;
                }

                markSum = markSum + currentMark;
            }

            averageGrade = markSum / (grade-1);

            if (badMark == 2) Console.WriteLine($"{studentsName} has been excluded at {grade} grade");
            if (badMark < 2) Console.WriteLine($"{studentsName} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
