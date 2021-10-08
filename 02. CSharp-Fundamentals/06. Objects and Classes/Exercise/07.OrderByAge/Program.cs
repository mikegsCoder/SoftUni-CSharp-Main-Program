using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                var currentInput = input.Split().ToArray();

                Person person = new Person(currentInput[0], 
                                int.Parse(currentInput[1]), 
                                int.Parse(currentInput[2]));

                persons.Add(person);
                input = Console.ReadLine();
            }
            foreach (var item in persons.OrderBy(x => x.Age))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public Person(string name, int id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            string text = $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
            return text.ToString();
        }
    }
}
