using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook_v01
{
    internal static class Program
    {
        private static void Main()
        {
            var dicOfSideAndPlayers = new Dictionary<string, List<string>>();

            string input;
            while ("Lumpawaroo" != (input = Console.ReadLine()))
            {
                if (input.Contains(" | "))
                {
                    var data = input.Split(" | ").ToArray();
                    var forceSide = data[0];
                    var forceUser = data[1];

                    if (PlayerExist(forceUser, dicOfSideAndPlayers))
                    {
                        continue;
                    }

                    if (!dicOfSideAndPlayers.ContainsKey(forceSide))
                    {
                        dicOfSideAndPlayers.Add(forceSide, new List<string>());
                    }

                    dicOfSideAndPlayers[forceSide].Add(forceUser);
                }
                else if (input.Contains(" -> "))
                {
                    var data = input.Split(" -> ").ToArray();
                    var forceUser = data[0];
                    var forceSide = data[1];

                    RemoveUser(forceUser, dicOfSideAndPlayers);

                    if (!dicOfSideAndPlayers.ContainsKey(forceSide))
                    {
                        dicOfSideAndPlayers.Add(forceSide, new List<string>());
                    }

                    dicOfSideAndPlayers[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var filtDicOfSideAndPlayers = dicOfSideAndPlayers
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            foreach (var (key, value) in filtDicOfSideAndPlayers)
            {
                Console.WriteLine($"Side: {key}, Members: {value.Count}");

                foreach (var names in value.OrderBy(name => name))
                {
                    Console.WriteLine($"! {names}");
                }
            }
        }

        private static void RemoveUser(string namePlayer, Dictionary<string, List<string>> dicOfSideAndPlayers)
        {
            foreach (var users in dicOfSideAndPlayers.Values)
            {
                users.Remove(namePlayer);
            }
        }

        private static bool PlayerExist(string namePlayer, Dictionary<string, List<string>> dicOfSideAndPlayers)
        {
            return dicOfSideAndPlayers
                .SelectMany(item => item.Value)
                .Any(name => name == namePlayer);
        }
    }
}