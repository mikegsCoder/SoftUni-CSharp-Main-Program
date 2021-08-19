using System;
using System.Collections.Generic;

namespace _08._CSharp_Fundamentals_Strings_and_Text_Processing_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var validUsernames = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];

                if (current.Length >= 3 && current.Length <= 16)
                {
                    bool isValid = true;
                    for (int j = 0; j < current.Length; j++)
                    {
                        if (!(char.IsLetterOrDigit(current[j]) || current[j] == '-' || current[j] == '_'))
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        validUsernames.Add(current);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,validUsernames));
        }
    }
}
