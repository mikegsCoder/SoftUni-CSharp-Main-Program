using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CSharp_Advanced_Stacks_and_Queues_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            Stack<int> elements = new Stack<int>();
            int[] numbersToPush = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        
            for (int i = 0; i < n; i++)
            {
                elements.Push(numbersToPush[i]);
            }

            for (int i = 0; i < s; i++)
            {
                elements.Pop();
            }

            if (elements.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (elements.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minElement = elements.Pop();

                while (elements.Count > 0)
                {
                    minElement = Math.Min(minElement, elements.Pop());
                }

                Console.WriteLine(minElement);
            }
        }
    }
}
