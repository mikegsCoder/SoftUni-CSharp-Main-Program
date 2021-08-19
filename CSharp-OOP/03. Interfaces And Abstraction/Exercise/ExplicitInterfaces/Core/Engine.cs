using System;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();

                Citizen citizen = new Citizen(args[0], args[1], int.Parse(args[2]));
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
