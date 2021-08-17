﻿using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w*)@(?<host>[a-zA-Z]+([.-]?[a-zA-Z]+)*[\.][a-zA-Z]{2,})";

            var matches = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
