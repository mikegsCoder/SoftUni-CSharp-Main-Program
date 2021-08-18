using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentHero = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!heroes.ContainsKey(currentHero[0]))
                {
                    heroes.Add(currentHero[0], new List<int>());
                    heroes[currentHero[0]].Add(int.Parse(currentHero[1]));
                    heroes[currentHero[0]].Add(int.Parse(currentHero[2]));
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] currentCommand = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string heroName = currentCommand[1];

                switch (currentCommand[0])
                {
                    case "CastSpell":                        
                        int mpNeeded = int.Parse(currentCommand[2]);
                        string spellName = currentCommand[3];
                        if (heroes.ContainsKey(heroName))
                        {
                            if (heroes[heroName][1] >= mpNeeded)
                            {
                                heroes[heroName][1] -= mpNeeded;
                                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                            }
                        }
                        break;
                    case "TakeDamage":                        
                        int damage = int.Parse(currentCommand[2]);
                        string attacker = currentCommand[3];
                        if (heroes.ContainsKey(heroName))
                        {
                            heroes[heroName][0] -= damage;
                            if (heroes[heroName][0] > 0)
                            {
                                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                            }
                            else
                            {
                                heroes.Remove(heroName);
                                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            }
                        }
                            break;
                    case "Recharge":
                        int rechargeAmmount = int.Parse(currentCommand[2]);
                        if (heroes.ContainsKey(heroName))
                        {
                            if (heroes[heroName][1] + rechargeAmmount > 200)
                            {
                                rechargeAmmount = 200 - heroes[heroName][1];
                            }

                            heroes[heroName][1] += rechargeAmmount; 
                            Console.WriteLine($"{heroName} recharged for {rechargeAmmount} MP!");
                        }
                            break;
                    case "Heal":
                        int healAmmount = int.Parse(currentCommand[2]);
                        if (heroes.ContainsKey(heroName))
                        {
                            if (heroes[heroName][0] + healAmmount > 100)
                            {
                                healAmmount = 100 - heroes[heroName][0];
                            }

                            heroes[heroName][0] += healAmmount;
                            Console.WriteLine($"{heroName} healed for {healAmmount} HP!");
                        }
                            break;
                }
            }

            foreach (var hero in heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {                
                Console.WriteLine(hero.Key);
                Console.WriteLine($"HP: {hero.Value[0]}");
                Console.WriteLine($"MP: {hero.Value[1]}");
            }
        }
    }
}
