using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Dictionary<string, int[]> people = new Dictionary<string, int[]>();

            string input = string.Empty;
                       
            while ((input = Console.ReadLine()) != "Results")
            {
                string[] currCommand = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                switch (currCommand[0])
                {
                    case "Add":
                        string currPerson = currCommand[1];
                        int currHealth = int.Parse(currCommand[2]);
                        int currEnergy = int.Parse(currCommand[3]);

                        if (!people.ContainsKey(currPerson))
                        {
                            people.Add(currPerson, new int[2] { currHealth, currEnergy });
                        }
                        else
                        {
                            people[currPerson][0] += currHealth;
                        }
                        break;
                    case "Attack":
                        string attackerName = currCommand[1];
                        string defenderName = currCommand[2];
                        int damage = int.Parse(currCommand[3]);

                        if (people.ContainsKey(attackerName) && people.ContainsKey(defenderName))
                        {
                            people[defenderName][0] -= damage;

                            if (people[defenderName][0] <= 0)
                            {
                                people.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }

                            people[attackerName][1]--;

                            if (people[attackerName][1] <= 0)
                            {
                                people.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }
                        break;
                    case "Delete":
                        string userName = currCommand[1];

                        if (userName == "All")
                        {
                            people.Clear();
                        }
                        else if (people.ContainsKey(userName))
                        {
                            people.Remove(userName);
                        }
                        break;
                }
            }

            Console.WriteLine($"People count: {people.Count}");

            foreach (var person in people.OrderByDescending(p => p.Value[0]).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{person.Key} - {person.Value[0]} - {person.Value[1]}");
            }
        }
    }
}
