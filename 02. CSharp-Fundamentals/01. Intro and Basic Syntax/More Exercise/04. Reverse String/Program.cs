using System;

namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int stringLength = inputString.Length - 1;
            string reverseString = "";

            while (stringLength >= 0)
            {
                reverseString = reverseString + inputString[stringLength];
                stringLength--;
            }

            Console.WriteLine(reverseString);
        }
    }
}
