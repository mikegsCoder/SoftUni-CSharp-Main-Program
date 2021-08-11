using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split();
                        
            for (int i = splitted.Length-1; i >= 0; i--)
            {
                Console.Write(splitted[i]+" ");
            }
        }
    }
}
