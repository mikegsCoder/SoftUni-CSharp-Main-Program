using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._CSharp_Fundamentals_Associative_Arrays_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var submissions = new Dictionary<string, Dictionary<string, int>>();

            string contestInput = string.Empty;

            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string contest = contestInput.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
                string password = contestInput.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray()[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            string submissionsInput = string.Empty;

            while ((submissionsInput = Console.ReadLine()) != "end of submissions")
            {
                string[] currentSubmission = submissionsInput
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCostest = currentSubmission[0];
                string currentPassword = currentSubmission[1];
                string userName = currentSubmission[2];
                int points = int.Parse(currentSubmission[3]);

                if (contests.ContainsKey(currentCostest) && contests[currentCostest] == currentPassword)
                {
                    if (!submissions.ContainsKey(userName))
                    {
                        submissions.Add(userName, new Dictionary<string, int>());
                        submissions[userName].Add(currentCostest, points);
                    }
                    else if(submissions.ContainsKey(userName) && !submissions[userName].ContainsKey(currentCostest))
                    {
                        submissions[userName].Add(currentCostest, points);
                    }
                    else if(submissions[userName][currentCostest] < points)
                    {
                        submissions[userName][currentCostest] = points;
                    }
                }
            }

            string bestStudent = string.Empty;
            int bestPoints = 0;

            foreach (var student in submissions)
            {
                int currentPoints = 0;
                foreach (var contest in student.Value)
                {
                    currentPoints += contest.Value;
                }
                if (currentPoints > bestPoints)
                {
                    bestPoints = currentPoints;
                    bestStudent = student.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var student in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(y => y.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
