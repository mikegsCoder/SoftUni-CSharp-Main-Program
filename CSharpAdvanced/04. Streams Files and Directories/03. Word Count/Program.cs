using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            string[] lines = File.ReadAllLines("text.txt");
            Dictionary<string, int> occurancies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!occurancies.ContainsKey(word))
                {
                    occurancies.Add(word, 0);
                }
            }

            foreach (var line in lines)
            {
                string[] lineWords = line
                    .Split(new char[] { ' ', '-', ',', '.' }
                    , StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in lineWords)
                {
                    if (occurancies.ContainsKey(word.ToLower()))
                    {
                        occurancies[word.ToLower()]++;
                    }
                }
            }

            string[] result = new string[occurancies.Count];

            int counter = 0;
            foreach (var occurancy in occurancies.OrderByDescending(x => x.Value))
            {
                result[counter] = $"{occurancy.Key} - {occurancy.Value}";
                counter++;
            }

            File.WriteAllLines("../../../actualResult.txt", result);
        }
    }
}
