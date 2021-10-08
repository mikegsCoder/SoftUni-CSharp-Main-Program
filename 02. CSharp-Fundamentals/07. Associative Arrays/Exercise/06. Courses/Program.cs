using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string courseName = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries)[0].ToString();
                string studentName = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries)[1].ToString();

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }
            }

            foreach (var pair in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine(pair.Key +": " + pair.Value.Count);
                List<string> students = pair.Value;
                students.Sort();

                foreach (var student in students)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}
