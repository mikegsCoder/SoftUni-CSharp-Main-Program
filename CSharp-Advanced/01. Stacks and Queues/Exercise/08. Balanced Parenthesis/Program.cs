using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isBallanced = true;

            string input = Console.ReadLine();

            Stack<char> parenthesis = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    parenthesis.Push(input[i]);
                }
                else
                {
                    if (parenthesis.Count > 0 && input[i] == ')' && parenthesis.Peek() == '(')
                    {
                        parenthesis.Pop();
                    }
                    else if (parenthesis.Count > 0 && input[i] == '}' && parenthesis.Peek() == '{')
                    {
                        parenthesis.Pop();
                    }
                    else if (parenthesis.Count > 0 && input[i] == ']' && parenthesis.Peek() == '[')
                    {
                        parenthesis.Pop();
                    }
                    else
                    {
                        isBallanced = false;
                        break;
                    }
                }
            }

            if (isBallanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
