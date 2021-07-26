using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] currentContest = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contestName = currentContest[0];
                string contestPassword = currentContest[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, contestPassword);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] currentCandidate = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currentCandidateContest = currentCandidate[0];
                string currentCandidatePassword = currentCandidate[1];
                string currentCandidateName = currentCandidate[2];
                int currentCandidatePoints = int.Parse(currentCandidate[3]);

                if (contests.ContainsKey(currentCandidateContest)
                    && contests[currentCandidateContest] == currentCandidatePassword)
                {
                    if (!candidates.ContainsKey(currentCandidateName))
                    {
                        candidates.Add(currentCandidateName, new Dictionary<string, int>());
                    }
                    if (!candidates[currentCandidateName].ContainsKey(currentCandidateContest))
                    {
                        candidates[currentCandidateName].Add(currentCandidateContest, currentCandidatePoints);
                    }
                    if (candidates[currentCandidateName][currentCandidateContest] < currentCandidatePoints)
                    {
                        candidates[currentCandidateName][currentCandidateContest] = currentCandidatePoints;
                    }
                }
            }

            string bestCandidate = string.Empty;
            int bestCandidatePoints = 0;

            foreach (var candidate in candidates)
            {
                int points = 0;
                foreach (var course in candidate.Value)
                {
                    points += course.Value;
                }

                if (points > bestCandidatePoints)
                {
                    bestCandidatePoints = points;
                    bestCandidate = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                                
                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
