using System;
using System.Collections.Generic;

namespace P05ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] PersonInfo = input.Split();
                Person person = new Person(PersonInfo[0],int.Parse(PersonInfo[1]),PersonInfo[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = people[n - 1];

            int matches = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
        }
    }
}
