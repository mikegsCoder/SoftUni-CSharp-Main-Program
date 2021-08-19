using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int letters = 0;
                int punctuals = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (Char.IsLetter(lines[i][j]))
                    {
                        letters++;
                    }
                    else if (Char.IsPunctuation(lines[i][j]))
                    {
                        punctuals++;
                    }
                }
                lines[i] = $"Line{i + 1} {lines[i]} ({letters})({punctuals})";
                
                File.WriteAllLines("../../../output.txt", lines);
            }
        }
    }
}
