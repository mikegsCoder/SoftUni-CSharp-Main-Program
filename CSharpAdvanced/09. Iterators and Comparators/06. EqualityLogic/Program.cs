using System;
using System.Collections.Generic;

namespace P06EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hPeople = new HashSet<Person>();
            List<Person> lPeople = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);

                Person person = new Person(name, age);

                hPeople.Add(person);
                if (!lPeople.Contains(person))
                {
                    lPeople.Add(person);
                }
            }

            Console.WriteLine(hPeople.Count);
            Console.WriteLine(lPeople.Count);
        }
    }
}
