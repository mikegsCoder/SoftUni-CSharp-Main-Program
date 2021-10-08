using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();

            Dictionary<string, int> materials = new Dictionary<string, int>();

            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            while (materials["shards"] < 250 && materials["fragments"] < 250 && materials["motes"] < 250 )
            {
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                int count = 0;
                string key = "";
                int value = 0;
                bool legandaryObtained = false;

                for (int i = 0; i < input.Count; i++)
                {
                    count++;
                    key = "";

                    if (count % 2 == 0)
                    {
                        key = input[i].ToLower();                        
                    }
                    else
                    {
                        value = int.Parse(input[i]);
                    }

                    if (key != "" && !materials.ContainsKey(key))
                    {
                        materials.Add(key, value);
                    }
                    else if (key != "" && materials.ContainsKey(key))
                    {
                        materials[key] += value;
                        if (materials["shards"] >= 250 || materials["fragments"] >= 250 || materials["motes"] >= 250)
                        {
                            legandaryObtained = true;
                            break;
                        }
                    }                    
                }

                if (legandaryObtained)
                {
                    break;
                }
            }

            bool shadowmourneObtained = false;
            bool valanyrObtained = false;
            bool dragonwrathObtained = false;
                        
            if (materials["shards"] >= 250)
            {
                shadowmourneObtained = true;
                materials["shards"] -= 250;
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (materials["fragments"] >= 250)
            {
                valanyrObtained = true;
                materials["fragments"] -= 250;
                Console.WriteLine("Valanyr obtained!");
            }
            else if (materials["motes"] >= 250)
            {
                dragonwrathObtained = true;
                materials["motes"] -= 250;
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> legendary = new Dictionary<string, int>();

            if (materials.ContainsKey("fragments"))
            {
                legendary.Add("fragments",materials["fragments"]);
                materials.Remove("fragments");
            }

            if (materials.ContainsKey("shards"))
            {
                legendary.Add("shards", materials["shards"]);
                materials.Remove("shards");
            }

            if (materials.ContainsKey("motes"))
            {
                legendary.Add("motes", materials["motes"]);
                materials.Remove("motes");
            }

            foreach (var pair in legendary.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }

            foreach (var pair in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }
    }
}
