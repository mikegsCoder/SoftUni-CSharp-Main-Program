﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		int key = int.Parse(Console.ReadLine());

		string pattern = @"@(?<name>[A-Za-z]+)([^-@!:>]+)?![G]!";

		List<string> kids = new List<string>();

		while (true)
		{
			string command = Console.ReadLine();

			if (command == "end")
			{
				break;
			}

			string input = string.Empty;

			for (int i = 0; i < command.Length; i++)
			{
				char curr = command[i];

				if (char.IsDigit(curr))
				{
					int currAsNum = int.Parse(curr.ToString());
					currAsNum -= key;
					input += currAsNum;
				}
				else
				{
					int currAsNum = (int)curr;
					currAsNum -= key;
					char toAdd = (char)currAsNum;
					input += toAdd;
				}
			}

			if (Regex.IsMatch(input, pattern))
			{
				Match match = Regex.Match(input, pattern);

				string name = match.Groups["name"].Value;

				kids.Add(name);
			}
		}

		foreach (string name in kids)
		{
			Console.WriteLine(name);
		}
	}
}