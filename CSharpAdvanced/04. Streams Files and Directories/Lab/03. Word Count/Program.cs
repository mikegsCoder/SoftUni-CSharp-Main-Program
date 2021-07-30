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
            StreamReader readerText = new StreamReader("../../../text.txt");
            StreamReader readerWords = new StreamReader("../../../words.txt");
            StreamWriter writer = new StreamWriter("../../../output.txt");

            Dictionary<string, int> occurancies = new Dictionary<string, int>();

            using (readerWords)
            {
                string[] words = readerWords.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    if (!occurancies.ContainsKey(words[i].ToLower()))
                    {
                        occurancies.Add(words[i].ToLower(), 0);
                    }
                }
            }

            using (readerText)
            {
                string line = readerText.ReadLine();

                while (line != null)
                {
                    string[] text = line.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (occurancies.ContainsKey(text[i].ToLower()))
                        {
                            occurancies[text[i].ToLower()]++;
                        }
                    }
                    
                    line = readerText.ReadLine();
                }                
            }

            using (writer)
            {
                foreach (var word in occurancies.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
