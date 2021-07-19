using System;
using System.IO;
using System.Linq;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                string line = string.Empty;
                int counter = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < words.Length; i++)
                        {
                            string temp = words[i];
                            
                            if (words[i].Contains('-'))
                            {
                                words[i] = words[i].Replace('-', '@');
                            }
                            if (words[i].Contains(','))
                            {
                                words[i] = words[i].Replace(',', '@');
                            }
                            if (words[i].Contains('.'))
                            {
                                words[i] = words[i].Replace('.', '@');
                            }
                            if (words[i].Contains('!'))
                            {
                                words[i] = words[i].Replace('!', '@');
                            }
                            if (words[i].Contains('?'))
                            {
                                words[i] = words[i].Replace('?', '@');
                            }
                        }

                        Console.WriteLine(string.Join(' ', words.Reverse()));
                    }
                }
            }
        }
    }
}
