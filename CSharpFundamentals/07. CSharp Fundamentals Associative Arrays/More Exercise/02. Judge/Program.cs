using System;
using System.Collections.Generic;
using System.Linq;

namespace dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsWithUsernameAndPoints = new Dictionary<string, Dictionary<string, int>>();
            var usernamesAndTotalPoints = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputArray = input.Split(" -> ");
                string username = inputArray[0];
                string contest = inputArray[1];
                int points = int.Parse(inputArray[2]);

                if (contestsWithUsernameAndPoints.ContainsKey(contest) == false)
                {
                    if (usernamesAndTotalPoints.ContainsKey(username) == false)
                    {
                        contestsWithUsernameAndPoints[contest] = new Dictionary<string, int>();
                        contestsWithUsernameAndPoints[contest].Add(username, points);
                        usernamesAndTotalPoints[username] = points;
                    }

                    else if (usernamesAndTotalPoints.ContainsKey(username) == true)
                    {
                        contestsWithUsernameAndPoints[contest] = new Dictionary<string, int>();
                        contestsWithUsernameAndPoints[contest].Add(username, points);
                        usernamesAndTotalPoints[username] += points;
                    }
                }

                else if (contestsWithUsernameAndPoints.ContainsKey(contest) == true)
                {
                    if (usernamesAndTotalPoints.ContainsKey(username) == false)
                    {
                        contestsWithUsernameAndPoints[contest].Add(username, points);
                        usernamesAndTotalPoints[username] = points;
                    }

                    else if (usernamesAndTotalPoints.ContainsKey(username) == true)
                    {
                        bool theUserAlreadyExistInContest = false;
                        foreach (var kvp in contestsWithUsernameAndPoints[contest])
                        {
                            string currentUsername = kvp.Key;
                            int currentPoints = kvp.Value;

                            if (currentUsername == username)
                            {
                                theUserAlreadyExistInContest = true;
                                if (points > currentPoints)
                                {
                                    contestsWithUsernameAndPoints[contest][username] = points;//entry in contest and then in the username value
                                    usernamesAndTotalPoints[username] -= currentPoints;
                                    usernamesAndTotalPoints[username] += points;
                                    theUserAlreadyExistInContest = true;
                                    break;
                                }
                            }
                        }

                        if (theUserAlreadyExistInContest == false)
                        {
                            contestsWithUsernameAndPoints[contest].Add(username, points);
                            usernamesAndTotalPoints[username] += points;
                        }
                    }
                }
            }

            foreach (var kvp in contestsWithUsernameAndPoints)
            {
                string contest = kvp.Key;
                var usernameAndPointsDictionary = kvp.Value;
                int k = 1;
                Console.WriteLine($"{contest}: {contestsWithUsernameAndPoints[contest].Count()} participants");

                foreach (var usernameAndPoints in contestsWithUsernameAndPoints[contest].OrderByDescending(x => x.Value)
                                                                                        .ThenBy(x => x.Key))
                {
                    string username = usernameAndPoints.Key;
                    int points = usernameAndPoints.Value;
                    Console.WriteLine($"{k}. {username} <::> {points}");
                    k++;
                }
            }

            Console.WriteLine("Individual standings:");
            int i = 1;

            foreach (var kvp in usernamesAndTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                string username = kvp.Key;
                int totalPoints = kvp.Value;
                Console.WriteLine($"{i}. {username} -> {totalPoints}");
                i++;
            }
        }
    }
}