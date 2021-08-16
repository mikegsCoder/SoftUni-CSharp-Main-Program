using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string first = input.Split()[0];
            string second = input.Split()[1];   
            
            Console.WriteLine(CharMultiplier(first, second));
        }

        static int CharMultiplier(string first, string second)
        {
            int sum = 0;
            for (int i = 0; i < Math.Max(first.Length, second.Length); i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    sum += (int)first[i] * (int)second[i];                    
                }
                else if (i >= first.Length && i < second.Length)
                {
                    sum += (int)second[i];
                }
                else if (i < first.Length && i >= second.Length)
                {
                    sum += (int)first[i];
                }
            }
                        
            return sum;
        }
    }
}
