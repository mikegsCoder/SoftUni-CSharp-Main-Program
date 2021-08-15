using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, int> resources = new Dictionary<string, int>();

            int counter = 0;
            string key = "";

            while ((input = Console.ReadLine()) != "stop")
            {
                counter++;

                if (counter % 2 != 0)
                {
                    key = input;
                }
                else
                {
                    int value = int.Parse(input);
                    if (!resources.ContainsKey(key))
                    {
                        resources.Add(key, value);
                    }
                    else
                    {
                        resources[key] += value;
                    }
                }
            }

            foreach (var pair in resources)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
