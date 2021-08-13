using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());

            HouseParty(commands);
        }

        static void HouseParty(int n)
        {
            List<string> guests = new List<string>();

            string input = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine();
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand.Length == 3)
                {
                    bool isInTheList = false;
                    for (int j = 0; j < guests.Count; j++)
                    {
                        if (guests[j] == currentCommand[0])
                        {
                            Console.WriteLine($"{currentCommand[0]} is already in the list!");
                            isInTheList = true;
                            break;
                        }
                    }

                    if (!isInTheList)
                    {
                        guests.Add(currentCommand[0]);
                    }
                }
                else
                {
                    bool isNotInTheList = true;

                    for (int j = 0; j < guests.Count; j++)
                    {
                        if (guests[j] == currentCommand[0])
                        {
                            guests.Remove(currentCommand[0]);
                            isNotInTheList = false;
                            break;
                        }
                    }

                    if (isNotInTheList)
                    {
                        Console.WriteLine($"{currentCommand[0]} is not in the list!");
                    }
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
