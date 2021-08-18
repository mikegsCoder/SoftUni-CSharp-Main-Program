using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<string> output = new List<string>();

            string pattern = @"\#{1}[A-z]{3,}\#{2}[A-z]{3,}\#{1}|\@{1}[A-z]{3,}\@{2}[A-z]{3,}\@{1}";

            string input = Console.ReadLine();

            var wordPairs = Regex.Matches(input, pattern);

            if (wordPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{wordPairs.Count} word pairs found!");

                foreach (Match pair in wordPairs)
                {
                    string[] words = pair.Value
                        .Split(new char[] { '@', '#' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string reversed = string.Empty;

                    for (int i = words[1].Length-1; i > -1; i--)
                    {
                        reversed += words[1][i];
                    }
                    if (words[0].Equals(reversed))
                    {
                        output.Add(words[0] + " <=> " + words[1]);
                    }
                }
                if (output.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ",output));
                }
            }
        }
    }
}
