using System;
using System.Collections.Generic;

using BorderControl.Models;
using BorderControl.Interfaces;

namespace BorderControl.Core
{
    public class Engine
    {
        public Engine()
        {
        }
        public void Run()
        {
            List<IBuyer> members = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArguments = Console.ReadLine().Split();

                if (inputArguments.Length == 4)
                {
                    Citizen citizen = new Citizen(
                       inputArguments[0],
                       int.Parse(inputArguments[1])
                       , inputArguments[2]
                       , inputArguments[3]);

                    members.Add(citizen);
                }
                if (inputArguments.Length == 3)
                {
                    Rebel rebel = new Rebel(
                        inputArguments[0],
                       int.Parse(inputArguments[1]),
                       inputArguments[2]);

                    members.Add(rebel);
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var member in members)
                {
                    if (member.Name == input)
                    {
                        member.BuyFood();
                    }
                }
            }

            int food = 0;

            foreach (var member in members)
            {
                food += member.Food;
            }

            Console.WriteLine(food);
        }
    }
}
