using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] dresses = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < dresses.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(dresses[j]))
                    {
                        wardrobe[color].Add(dresses[j], 0);
                    }
                    wardrobe[color][dresses[j]]++;
                }
            }

            string[] dressToFind = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var dress in color.Value)
                {
                    if (color.Key == dressToFind[0] && dress.Key == dressToFind[1])
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}
