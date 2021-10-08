using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int minIndex = Math.Min((int)firstChar, (int)secondChar);
            int maxIndex = Math.Max((int)firstChar, (int)secondChar);

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if ((int)input[i] > minIndex && (int)input[i] < maxIndex )
                {
                    sum += (int)input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
