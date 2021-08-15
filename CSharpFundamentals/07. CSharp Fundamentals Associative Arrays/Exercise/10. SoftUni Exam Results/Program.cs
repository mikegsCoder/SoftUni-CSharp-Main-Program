using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var examResults = new Dictionary<string, int>();
            var exams = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                if (input.Contains("banned"))
                {
                    string nameBanned = input.Split('-')[0];

                    if (examResults.ContainsKey(nameBanned))
                    {
                        examResults.Remove(nameBanned);
                    }
                }
                else
                {
                    string name = input.Split('-')[0];
                    string language = input.Split('-')[1];
                    int points = int.Parse(input.Split('-')[2]);

                    if (!examResults.ContainsKey(name))
                    {
                        examResults.Add(name, points);
                    }
                    else if(examResults[name] < points)
                    {
                        examResults[name] = points;
                    }

                    if (!exams.ContainsKey(language))
                    {
                        exams.Add(language, 1);
                    }
                    else
                    {
                        exams[language] += 1;
                    }
                }
            }

            Console.WriteLine("Results:");

            foreach (var pair in examResults.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine(pair.Key + " | " + pair.Value);
            }

            Console.WriteLine("Submissions:");

            foreach (var pair in exams.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
        }
    }
}
