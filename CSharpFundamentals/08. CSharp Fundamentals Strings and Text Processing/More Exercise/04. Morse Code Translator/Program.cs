using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, char> morseCode = new Dictionary<string, char>();

            morseCode.Add(".-", 'A');
            morseCode.Add("-...", 'B');
            morseCode.Add("-.-.", 'C');
            morseCode.Add("-..", 'D');
            morseCode.Add(".", 'E');
            morseCode.Add("..-.", 'F');
            morseCode.Add("--.", 'G');
            morseCode.Add("....", 'H');
            morseCode.Add("..", 'I');
            morseCode.Add(".---", 'J');
            morseCode.Add("-.-", 'K');
            morseCode.Add(".-..", 'L');
            morseCode.Add("--", 'M');
            morseCode.Add("-.", 'N');
            morseCode.Add("---", 'O');
            morseCode.Add(".--.", 'P');
            morseCode.Add("--.-", 'Q');
            morseCode.Add(".-.", 'R');
            morseCode.Add("...", 'S');
            morseCode.Add("-", 'T');
            morseCode.Add("..-", 'U');
            morseCode.Add("...-", 'V');
            morseCode.Add(".--", 'W');
            morseCode.Add("-..-", 'X');
            morseCode.Add("-.--", 'Y');
            morseCode.Add("--..", 'Z');

            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = CWdecoder(input[i], morseCode);
            }

            Console.WriteLine(string.Join(' ',output));
        }
        static string CWdecoder(string input, Dictionary<string,char> morseCode)
        {
            string decodedWord = string.Empty;
            List<string> letters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < letters.Count; i++)
            {
                if (morseCode.ContainsKey(letters[i]))
                {
                    sb.Append(morseCode[letters[i]]);
                }
            }

            decodedWord = sb.ToString();
            return decodedWord;
        }
    }
}
