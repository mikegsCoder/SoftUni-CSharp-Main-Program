using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> elements = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] currentCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (currentCommand[0])
                {
                    case 1:
                        elements.Push(currentCommand[1]);
                        break;
                    case 2:
                        if (elements.Count > 0)
                        {
                            elements.Pop();
                        }
                        break;
                    case 3:
                        if (elements.Count > 0)
                        {
                            Console.WriteLine(elements.Max());
                        }
                        break;
                    case 4:
                        if (elements.Count > 0)
                        {
                            Console.WriteLine(elements.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
