using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (IsPalindrome(input))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string input)
        {
            string reverse = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse += input[i];
            }
            if (input.CompareTo(reverse) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
