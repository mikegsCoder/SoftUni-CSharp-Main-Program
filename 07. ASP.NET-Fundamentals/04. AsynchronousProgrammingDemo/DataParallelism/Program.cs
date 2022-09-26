﻿namespace DataParallelism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = new List<int>() { 1, 2, 3 };


            Parallel.For(0, elements.Count, i =>
            {
                Console.WriteLine(elements[i]);
            });

        }
    }
}