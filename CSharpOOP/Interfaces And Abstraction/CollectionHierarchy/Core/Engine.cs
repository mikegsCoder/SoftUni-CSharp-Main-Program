using System;
using System.Collections.Generic;
using System.Text;

using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;
        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }
        public void Run()
        {
            string[] args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"{addCollection.Add(args[i])} ");
            }
            Console.WriteLine();

            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"{addRemoveCollection.Add(args[i])} ");
            }
            Console.WriteLine();

            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"{myList.Add(args[i])} ");
            }
            Console.WriteLine();

            int n = int.Parse(Console.ReadLine());

            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{addRemoveCollection.Remove()} ");
                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{myList.Remove()} ");
                }
                Console.WriteLine();
            }
        }
    }
}
