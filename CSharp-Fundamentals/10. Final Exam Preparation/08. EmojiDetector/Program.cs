using System;
using System.Text.RegularExpressions;

namespace _08.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string emojiPattern = @"::([A-Z][a-z]{2,})::|\*\*([A-Z][a-z]{2,})\*\*";

            var emojiMatches = Regex.Matches(input, emojiPattern);

            int coolTreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    coolTreshold *= int.Parse(input[i].ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match emoji in emojiMatches)
            {
                int coolness = 0;
                string currentEmoji = emoji.Value;

                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    if (currentEmoji[i] != '*' && currentEmoji[i] != ':')
                    {
                        coolness += (int)currentEmoji[i];
                    }
                }
                
                if (coolness >= coolTreshold)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }
    }
}
