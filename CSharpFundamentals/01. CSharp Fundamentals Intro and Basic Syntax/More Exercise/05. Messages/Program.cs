using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string two = "abc";
            string three = "def";
            string four = "ghi";
            string five = "jkl";
            string six = "mno";
            string seven = "pqrs";
            string eigth = "tuv";
            string nine = "wxyz";

            string message = "";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                char current = input[0];

                switch (current)
                {
                    case '2':
                        message += two[input.Length - 1];
                        break;
                    case '3':
                        message += three[input.Length - 1];
                        break;
                    case '4':
                        message += four[input.Length - 1];
                        break;
                    case '5':
                        message += five[input.Length - 1];
                        break;
                    case '6':
                        message += six[input.Length - 1];
                        break;
                    case '7':
                        message += seven[input.Length - 1];
                        break;
                    case '8':
                        message += eigth[input.Length - 1];
                        break;
                    case '9':
                        message += nine[input.Length - 1];
                        break;
                    case '0':
                        message += ' ';
                        break;
                }
            }

            Console.WriteLine(message);
        }
    }
}
