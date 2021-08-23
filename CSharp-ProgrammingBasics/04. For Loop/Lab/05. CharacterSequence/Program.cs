using System;

namespace _05.CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int length = text.Length;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
