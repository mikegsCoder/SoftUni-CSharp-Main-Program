﻿using System;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Problem 01:
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            //IPerson person = new Citizen(name, age);
            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);

            // Problem 02:
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
