using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var info in personInfo)
            {
                string[] currentInfo = info.Split('=').ToArray();
                string name = currentInfo[0];
                int money = int.Parse(currentInfo[1]);
                Person person = new Person(name, money);
                persons.Add(person);
            }

            string[] productInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var info in productInfo)
            {
                string[] currentInfo = info.Split('=').ToArray();
                string name = currentInfo[0];
                int cost = int.Parse(currentInfo[1]);
                Product product = new Product(name, cost);
                products.Add(product);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] currentInput = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currentName = currentInput[0];
                string currentProduct = currentInput[1];

                Product product = products.Find(x => x.ProductName == currentProduct);

                foreach (var person in persons)
                {
                    if (person.PersonName == currentName)
                    {
                        if (person.Money >= product.Cost)
                        {
                            person.AddProduct(currentProduct);
                            person.Money -= product.Cost;

                            Console.WriteLine($"{person.PersonName} bought {product.ProductName}");
                        }
                        else
                        {
                            Console.WriteLine($"{person.PersonName} can't afford {product.ProductName}");
                        }
                    }
                }
            }

            foreach (var person in persons)
            {
                if (person.Products.Count > 0)
                {
                    Console.Write($"{person.PersonName} - ");
                    Console.WriteLine(string.Join(", ",person.Products));                    
                }
                else
                {
                    Console.Write($"{person.PersonName} - Nothing bought");
                }
            }
        }
    }
    public class Person
    {
        public string PersonName { get; set; }
        public int Money { get; set; }

        public List<string> Products = new List<string>();        
 
        public Person(string name, int money)
        {
            this.PersonName = name;
            this.Money = money;
        }

         public void AddProduct(string product)
        {
            Products.Add(product);
        }        
    }
    public class Product
    {
        public string ProductName { get; set; }
        public int Cost { get; set; }

        public Product(string productName, int cost)
        {
            this.ProductName = productName;
            this.Cost = cost;
        }
    }    
}
