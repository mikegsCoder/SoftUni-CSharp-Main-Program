using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> targets = new Dictionary<string, List<int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] currentInput = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string town = currentInput[0];
                int population = int.Parse(currentInput[1]);
                int gold = int.Parse(currentInput[2]);

                if (!targets.ContainsKey(town))
                {
                    targets.Add(town, new List<int>());
                    targets[town].Add(population);
                    targets[town].Add(gold);
                }
                else
                {
                    targets[town][0] += population;
                    targets[town][1] += gold;
                }
            }

            input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currentCommand = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string town = currentCommand[1];

                switch (currentCommand[0])
                {
                    case "Plunder":
                        int people = int.Parse(currentCommand[2]);
                        int gold = int.Parse(currentCommand[3]);
                        if (targets.ContainsKey(town))
                        {
                            if (targets[town][0] < people)
                            {
                                people = targets[town][0];
                            }
                            if (targets[town][1] < gold)
                            {
                                gold = targets[town][1];
                            }

                            targets[town][0] -= people;
                            targets[town][1] -= gold;
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                            if (targets[town][0] <= 0 || targets[town][1] <= 0)
                            {
                                targets.Remove(town);
                                Console.WriteLine($"{town} has been wiped off the map!");
                            }
                        }
                        break;
                    case "Prosper":
                        int goldGrown = int.Parse(currentCommand[2]);
                        if (goldGrown < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            if (targets.ContainsKey(town))
                            {
                                targets[town][1] += goldGrown;
                                Console.WriteLine($"{goldGrown} gold added to the city treasury. {town} now has {targets[town][1]} gold.");
                            }
                        }
                        break;
                }
            }

            if (targets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");

                foreach (var target in targets.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{target.Key} -> Population: {target.Value[0]} citizens, Gold: {target.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
