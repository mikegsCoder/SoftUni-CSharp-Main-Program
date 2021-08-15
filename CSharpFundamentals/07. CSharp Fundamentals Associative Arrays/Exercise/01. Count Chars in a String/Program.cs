using System;
using System.Collections.Generic;

namespace _07._CSharp_Fundamentals_Associative_Arrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                if (!charsCount.ContainsKey(input[i]))
                {
                    charsCount.Add(input[i], 1);
                }
                else
                {
                    charsCount[input[i]]++;
                }
            }

            foreach (var pair in charsCount)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
