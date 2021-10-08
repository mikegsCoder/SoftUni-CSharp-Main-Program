using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char character1 = char.Parse(Console.ReadLine());
            char character2 = char.Parse(Console.ReadLine());
            PrintCharactersBetween(character1, character2);
        }
        static void PrintCharactersBetween(char start, char stop)
        {
            for (int i = Math.Min((int)start+1, (int)stop+1); i < Math.Max((int)stop,(int)start) ; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
