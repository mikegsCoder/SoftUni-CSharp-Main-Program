using System;
using System.Collections.Generic;
using System.Text;

namespace CompisitePattern
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public abstract decimal CalculateTotalPrice();
    }
}
