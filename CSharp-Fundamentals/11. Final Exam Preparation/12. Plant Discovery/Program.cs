using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentPlant = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantName = currentPlant[0];
                double rarity = double.Parse(currentPlant[1]);

                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, new List<double>() {rarity});                   
                }
                else
                {
                    plants[plantName][0] = rarity;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] curentCommand = input
                    .Split(new char[] { ' ', '-'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plant = curentCommand[1];
                
                switch (curentCommand[0])
                {
                    case "Rate:":
                        double rating = double.Parse(curentCommand[2]);
                        if (plants.ContainsKey(plant))
                        {
                            plants[plant].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update:":
                        double newRarity = double.Parse(curentCommand[2]);
                        if (plants.ContainsKey(plant))
                        {
                            plants[plant][0] = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset:":
                        if (plants.ContainsKey(plant))
                        {                            
                            plants[plant].RemoveRange(1, plants[plant].Count-1);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants)
            {
                string plantName = plant.Key;
                double rarity = plant.Value[0];
                double rating = 0.0;

                if (plant.Value.Count > 1)
                {
                    for (int i = 1; i < plant.Value.Count; i++)
                    {
                        rating += plant.Value[i];
                    }
                    rating /= (plant.Value.Count - 1);
                    plant.Value.RemoveRange(1, plant.Value.Count - 1);
                    plant.Value.Add(rating);
                }
                else
                {
                    plant.Value.Add(0.0);
                }                
            }

            foreach (var plant in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }
        }
    }
}
