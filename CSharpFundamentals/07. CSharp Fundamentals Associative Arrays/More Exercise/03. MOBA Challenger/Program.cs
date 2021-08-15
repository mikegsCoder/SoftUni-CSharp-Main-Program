using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var moba = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Season end")
            {
                if (!input.Contains(" vs "))
                {
                    string name = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[0];
                    string position = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[1];
                    int skill = int.Parse(input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[2]);

                    if (!moba.ContainsKey(name))
                    {
                        moba.Add(name, new Dictionary<string, int>());
                        moba[name].Add(position, skill);
                    }
                    else if (moba.ContainsKey(name) && !moba[name].ContainsKey(position))
                    {
                        moba[name].Add(position, skill);
                    }
                    else if (moba.ContainsKey(name) && moba[name].ContainsKey(position))
                    {
                        if (moba[name][position] < skill)
                        {
                            moba[name][position] = skill;
                        }
                    }
                }
                else
                {
                    string firstName = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries)[0];
                    string secondName = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries)[1];

                    bool firstPlayerExists = false;
                    bool secondPlayerExists = false;

                    int firstPlayerTotalSkill = 0;
                    int secondPlayerTotalSkill = 0;

                    if (firstName != secondName)
                    {
                        foreach (var player in moba)
                        {
                            if (player.Key == firstName && !firstPlayerExists)
                            {
                                firstPlayerExists = true;
                                foreach (var position in player.Value)
                                {
                                    firstPlayerTotalSkill += position.Value;
                                }
                            }
                            if (player.Key == secondName && !secondPlayerExists)
                            {
                                secondPlayerExists = true;
                                foreach (var position in player.Value)
                                {
                                    secondPlayerTotalSkill += position.Value;
                                }
                            }
                        }

                        bool isRemoved = false;

                        if (firstPlayerExists && secondPlayerExists)
                        {
                            foreach (var firstPlayerPosition in moba[firstName])
                            {
                                foreach (var secondPlayerPosition in moba[secondName])
                                {
                                    if (firstPlayerPosition.Key == secondPlayerPosition.Key)
                                    {
                                        if (firstPlayerTotalSkill > secondPlayerTotalSkill)
                                        {
                                            moba.Remove(secondName);
                                            isRemoved = true;
                                            break;
                                        }
                                        else if (firstPlayerTotalSkill < secondPlayerTotalSkill)
                                        {
                                            moba.Remove(firstName);
                                            isRemoved = true;
                                            break;
                                        }
                                    }
                                }

                                if (isRemoved)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            var playersList = new Dictionary<string, int>();

            foreach (var player in moba)
            {
                if (!playersList.ContainsKey(player.Key))
                {
                    playersList.Add(player.Key, 0);
                    int playerTotalSkill = 0;

                    foreach (var contest in player.Value)
                    {
                        playerTotalSkill += contest.Value;
                    }
                    playersList[player.Key] = playerTotalSkill;
                }
            }


            foreach (var player in playersList.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");

                foreach (var position in moba[player.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
