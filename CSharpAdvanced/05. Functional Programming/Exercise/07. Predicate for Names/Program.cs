using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
                        
            Func<string, int, bool> func = (name, length) => name.Length <= length;
            names = names.Where(name => func(name, n)).ToList();

            Action<List<string>> printer = names => Console.WriteLine(string.Join(Environment.NewLine,names));

            printer(names);
        }
    }
}
