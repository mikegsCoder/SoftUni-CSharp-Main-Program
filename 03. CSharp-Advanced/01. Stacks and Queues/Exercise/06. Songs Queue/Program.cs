using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            string input = Console.ReadLine();

            while (songs.Count > 0)
            {
                string[] currentCommand = input.Split().ToArray();

                switch (currentCommand[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string songToAdd = string.Empty;
                        for (int i = 1; i < currentCommand.Length-1; i++)
                        {
                            songToAdd += currentCommand[i] + " ";
                        }
                        songToAdd += currentCommand[currentCommand.Length - 1];
                        if (!songs.Contains(songToAdd))
                        {
                            songs.Enqueue(songToAdd);
                        }
                        else
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",songs));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
