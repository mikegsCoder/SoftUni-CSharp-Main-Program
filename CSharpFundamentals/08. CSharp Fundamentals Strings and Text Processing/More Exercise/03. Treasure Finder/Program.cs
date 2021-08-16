using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] key = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "find")
            {
                TreasureFinder(StringDecripter(key, input));
            }
        }

        static string StringDecripter(int[] key, string input)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            int keyCounter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currentKey = key[keyCounter];
                sb.Append((char)((int)input[i] - currentKey));
                keyCounter++;
                if (keyCounter == key.Length)
                {
                    keyCounter = 0;
                }
            }

            result = sb.ToString();
            return result;
        }
        static void TreasureFinder(string input)
        {
            string treasure = input.Substring(input.IndexOf('&') + 1, (input.LastIndexOf('&') - input.IndexOf('&') - 1));
            string coordinates = input.Substring(input.IndexOf('<') + 1, (input.LastIndexOf('>') - input.IndexOf('<') - 1));

            Console.WriteLine($"Found {treasure} at {coordinates}");
        }
    }
}
