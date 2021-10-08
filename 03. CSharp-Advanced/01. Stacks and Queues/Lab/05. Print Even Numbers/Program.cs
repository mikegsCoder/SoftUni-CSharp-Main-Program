using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNumbers = new Queue<int>();

            for (int i = 0; i < numbersArr.Length; i++)
            {
                if (numbersArr[i] % 2 == 0)
                {
                    evenNumbers.Enqueue(numbersArr[i]);
                }
            }

            while (evenNumbers.Count > 1)
            {
                Console.Write(evenNumbers.Dequeue() + ", ");
            }

            Console.Write(evenNumbers.Dequeue());
            Console.WriteLine();
        }
    }
}
