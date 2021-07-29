using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] currentStudent = Console.ReadLine().Split();
                string studentsName = currentStudent[0];
                decimal studentsGrade = decimal.Parse(currentStudent[1]);

                if (!studentsGrades.ContainsKey(studentsName))
                {
                    studentsGrades.Add(studentsName, new List<decimal>() { studentsGrade });
                }
                else
                {
                    studentsGrades[studentsName].Add(studentsGrade);
                }
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
