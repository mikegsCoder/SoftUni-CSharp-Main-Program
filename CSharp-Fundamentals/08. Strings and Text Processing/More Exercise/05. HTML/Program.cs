using System;
using System.Collections.Generic;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputText = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of comments")
            {
                inputText.Add(input);
            }

            HTMLcreator(inputText);
        }
        static void HTMLcreator(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("<h1>");
                    Console.WriteLine($"    {input[0]}");
                    Console.WriteLine("</h1>");
                }
                else if (i == 1)
                {
                    Console.WriteLine("<article>");
                    Console.WriteLine($"    {input[1]}");
                    Console.WriteLine("</article>");
                }
                else
                {
                    Console.WriteLine("<div>");
                    Console.WriteLine($"    {input[i]}");
                    Console.WriteLine("</div>");
                }
            }
        }
    }
}
