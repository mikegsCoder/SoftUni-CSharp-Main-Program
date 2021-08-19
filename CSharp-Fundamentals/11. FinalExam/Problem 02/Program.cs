using System;
using System.Text.RegularExpressions;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            string pattern = @"^([\$%])(?<tag>[A-Z][a-z]{2,})\1:\s\[(?<firstNumber>[0-9]+)\]\|\[(?<secondNumber>[0-9]+)\]\|\[(?<thindNumber>[0-9]+)\]\|$";

            int n = int.Parse(Console.ReadLine());
            
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = regex.Match(input);
                
                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value.ToString();
                    int firstNum = int.Parse(match.Groups["firstNumber"].Value);
                    int secondNum = int.Parse(match.Groups["secondNumber"].Value);
                    int thirdNum = int.Parse(match.Groups["thindNumber"].Value);
                 
                    char first = (char)firstNum;
                    char second = (char)secondNum;
                    char third = (char)thirdNum;
                 
                    string message = $"{first}{second}{third}";

                    Console.WriteLine($"{tag}: {message}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
