using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] currentInput = input
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currentInput[0];
                string color = currentInput[1];
                int physics = int.Parse(currentInput[2]);

                if (!dwarfs.ContainsKey(color))
                {
                    dwarfs.Add(color, new Dictionary<string, int>());
                    dwarfs[color].Add(name, physics);
                }
                else if (dwarfs.ContainsKey(color) && !dwarfs[color].ContainsKey(name))
                {
                    dwarfs[color].Add(name, physics);
                }
                else if (dwarfs.ContainsKey(color) && dwarfs[color].ContainsKey(name))
                {
                    if (dwarfs[color][name] < physics)
                    {
                        dwarfs[color][name] = physics;
                    }
                }
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var hatColor in dwarfs.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            } 
        }
    }
}
