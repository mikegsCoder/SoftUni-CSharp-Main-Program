using System;
using System.Collections.Generic;

using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string NOT_ENOUGH_MONEY_MSG = "{0} can't afford {1}";
        private const string HAS_ENOUGH_MONEY_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMsg);
                }

                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get 
            { 
                return (IReadOnlyCollection<Product>)this.bag; 
            }
            //private set
            //{
            //    this.bag = value;
            //}
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return String.Format(NOT_ENOUGH_MONEY_MSG, this.Name, product.Name);
            }

            this.Money -= product.Cost;
            bag.Add(product);
            return String.Format(HAS_ENOUGH_MONEY_MSG, this.Name, product.Name);
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) 
                : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
