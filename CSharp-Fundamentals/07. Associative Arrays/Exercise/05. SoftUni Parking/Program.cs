using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string command = input[0];
                string userName = input[1];
                string licensePlateNumber = string.Empty;

                if (input.Length == 3)
                {
                    licensePlateNumber = input[2];
                }
                else
                {

                }

                if (command == "register")
                {
                    if (!parking.ContainsKey(userName))
                    {
                        parking.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[userName]}");
                    }
                }
                else
                {
                    if (!parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        parking.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var pair in parking)
            {
                Console.WriteLine(pair.Key + " => " + pair.Value);
            }
        }
    }
}
