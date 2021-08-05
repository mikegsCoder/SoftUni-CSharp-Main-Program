using System;

using ShoppingSpree.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;
        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            // Place business logic here
            try
            {
                this.ParsePeopleInput();

                this.ParseProductsInput();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string personName = commandArgs[0];
                    string productName = commandArgs[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] peopleArgs = Console.ReadLine()
               .Split(';',StringSplitOptions.RemoveEmptyEntries);

            foreach (string personStr in peopleArgs)
            {
                string[] personArgs = personStr
                    .Split('=');
                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }

        private void ParseProductsInput()
        {
            string[] productsArgs = Console.ReadLine()
                  .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string productStr in productsArgs)
            {
                string[] productArgs = productStr
                    .Split('=');
                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }
    }
}
