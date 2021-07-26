using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int winningThread = -1;
            int currentTask;
            int currentThread;

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (tasks.Count > 0)
                {
                    currentTask = tasks.Peek();
                }
                else break;

                if (threads.Count > 0)
                {
                    currentThread = threads.Peek();
                }
                else break;

                if (currentTask == taskToBeKilled)
                {
                    winningThread = currentThread;
                    break;
                }

                if (currentThread < currentTask)
                {
                    threads.Dequeue();
                }                
                else
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {winningThread} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(' ',threads));
        }
    }
}
