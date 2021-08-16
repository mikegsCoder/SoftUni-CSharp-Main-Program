using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in banList)
            {
                int length = word.Length;
                string asteriks = new string('*', length);
                text = text.Replace(word, asteriks);
            }

            Console.WriteLine(text);
        }
    }
}
