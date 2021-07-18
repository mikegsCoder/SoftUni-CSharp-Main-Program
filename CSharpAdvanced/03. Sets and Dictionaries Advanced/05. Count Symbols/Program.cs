using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!chars.ContainsKey(input[i]))
                {
                    chars.Add(input[i], 0);
                }
                chars[input[i]]++;
            }

            foreach (var character in chars)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
