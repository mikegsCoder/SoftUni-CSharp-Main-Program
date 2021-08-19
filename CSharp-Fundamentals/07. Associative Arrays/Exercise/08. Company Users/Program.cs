using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string name = input.Split(" -> ")[0];
                string id = input.Split(" -> ")[1];

                if (!companies.ContainsKey(name))
                {
                    companies.Add(name, new List<string>());
                    companies[name].Add(id);
                }
                else
                {
                    if (!companies[name].Contains(id))
                    {
                        companies[name].Add(id);
                    }
                }
            }

            foreach (var pair in companies)
            {
                Console.WriteLine(pair.Key);

                foreach (var id in pair.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}
