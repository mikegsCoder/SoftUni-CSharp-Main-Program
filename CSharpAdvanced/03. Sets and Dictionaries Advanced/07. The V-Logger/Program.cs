using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            Dictionary<string, int> following = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] currentCommand = input.Split();

                switch (currentCommand[1])
                {
                    case "joined":
                        string bloggerToJoin = currentCommand[0];
                        if (!followers.ContainsKey(bloggerToJoin))
                        {
                            followers.Add(bloggerToJoin, new List<string>());
                            following.Add(bloggerToJoin, 0);
                        }
                        break;
                    case "followed":
                        string bloggerWhoFollow = currentCommand[0];
                        string bloggerFollowed = currentCommand[2];

                        if (bloggerWhoFollow != bloggerFollowed
                            && followers.ContainsKey(bloggerWhoFollow)
                            && followers.ContainsKey(bloggerFollowed)
                            && !followers[bloggerFollowed].Contains(bloggerWhoFollow))
                        {
                            followers[bloggerFollowed].Add(bloggerWhoFollow);
                            following[bloggerWhoFollow]++;
                        }
                        break;
                }
            }

            string theMostFamousVlogger = string.Empty;
            int followersCount = 0;

            foreach (var name in followers)
            {
                if (name.Value.Count > followersCount)
                {
                    followersCount = name.Value.Count;
                    theMostFamousVlogger = name.Key;
                }
            }

            List<string> mostFamousFollowers = new List<string>(followers[theMostFamousVlogger]);
            mostFamousFollowers.Sort();

            Dictionary<string, int[]> vloggers = new Dictionary<string, int[]>();

            foreach (var vlogger in followers)
            {
                vloggers.Add(vlogger.Key, new int[2] { vlogger.Value.Count, 0 });
            }
            foreach (var vlogger in following)
            {
                vloggers[vlogger.Key][1] += vlogger.Value;
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            if (vloggers.Count > 0)
            {
                if (theMostFamousVlogger != string.Empty)
                {
                    Console.WriteLine($"1. {theMostFamousVlogger} : {vloggers[theMostFamousVlogger][0]} followers, {vloggers[theMostFamousVlogger][1]} following");

                    vloggers.Remove(theMostFamousVlogger);

                    foreach (var follower in mostFamousFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                                
                int counter = 2;
                foreach (var vlogger in vloggers.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]))
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
                    counter++;
                }
            }
        }
    }
}
