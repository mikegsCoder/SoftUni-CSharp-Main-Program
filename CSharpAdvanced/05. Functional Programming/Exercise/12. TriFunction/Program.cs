using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> equalOrLarger = (name, length) =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += (int)name[i];
                }
                return sum >= length;
            };

            Action<string> printer = name => Console.WriteLine(name);

            Action<List<string>, int, Func<string, int, bool>, Action<string>> program = (names, length, condition, print) =>
                {
                    foreach (var name in names)
                    {
                        if (condition(name, length))
                        {
                            print(name);
                            break;
                        }
                    }
                };

            program(names, n, equalOrLarger, printer);
        }
    }
}
