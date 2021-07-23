using System;
using System.Collections.Generic;

namespace P05GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            string valueToCompare = Console.ReadLine();

            Console.WriteLine(Comparer(boxes, valueToCompare));
        }

        static int Comparer<T>(List<Box<T>> boxes, T valueToCompare) where T : IComparable
        {
            int counter = 0;
            foreach (var box in boxes)
            {
                if (box.MyCompare(box, valueToCompare))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
