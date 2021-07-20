using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = string.Empty;

            Func<int, int> arithmenicFunc = num => num;

            Action<List<int>> print = nums => Console.WriteLine(string.Join(' ',nums));

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    arithmenicFunc = num => num + 1;
                    numbers = numbers.Select(arithmenicFunc).ToList();
                }
                else if (command == "multiply")
                {
                    arithmenicFunc = num => num * 2;
                    numbers = numbers.Select(arithmenicFunc).ToList();
                }
                else if (command == "subtract")
                {
                    arithmenicFunc = num => num - 1;
                    numbers = numbers.Select(arithmenicFunc).ToList();
                }
                else if (command == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
