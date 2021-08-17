using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern1 = @"\$[A-Z]+\$|\#[A-Z]+\#|\%[A-Z]+\%|\*[A-Z]+\*|\&[A-Z]+\&";
            string pattern2 = @"\d{2}:\d{2}";

            var letters = Regex.Match(input[0], pattern1);

            string firstLetters = letters.Value.Substring(1, letters.Value.Length - 2);
            List<int> wordLength = new List<int>();

            var wordLengths = Regex.Matches(input[1], pattern2);

            for (int i = 0; i < firstLetters.Length; i++)
            {
                bool isChecked = false;
                foreach (Match item in wordLengths)
                {
                    int[] lengths = item.Value
                        .Split(':', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    if ((char)lengths[0] == firstLetters[i] && !isChecked)
                    {
                        wordLength.Add(lengths[1] + 1);
                        isChecked = true;
                        continue;
                    }
                }
            }

            List<string> words = input[2]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < firstLetters.Length; i++)
            {
                foreach (var word in words)
                {
                    if (word[0] == firstLetters[i] && word.Length == wordLength[i])
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
