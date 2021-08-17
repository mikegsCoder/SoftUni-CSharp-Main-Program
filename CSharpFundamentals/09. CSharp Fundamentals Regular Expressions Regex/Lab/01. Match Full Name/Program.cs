using System;
using System.Text.RegularExpressions;

namespace _09._CSharp_Fundamentals_Regular_Expressions_Regex_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, regex);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
