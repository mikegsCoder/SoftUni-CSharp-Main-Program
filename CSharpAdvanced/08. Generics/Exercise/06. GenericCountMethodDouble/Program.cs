using System;
using System.Collections.Generic;

namespace P06GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double valueToCompare = double.Parse(Console.ReadLine());

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
