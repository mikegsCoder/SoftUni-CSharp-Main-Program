using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] currentCommand = command.Split().ToArray();

                if (currentCommand[0] == "add")
                {
                    for (int i = 1; i < currentCommand.Length; i++)
                    {
                        stack.Push(int.Parse(currentCommand[i]));
                    }
                }
                else if (currentCommand[0] == "remove" && int.Parse(currentCommand[1]) <= stack.Count)
                {                    
                    for (int i = 0; i < int.Parse(currentCommand[1]); i++)
                    {
                        stack.Pop();
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
