using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] arr2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        Console.Write($"{arr2[i]} ");
                    }
                }
            }
        }
    }
}
