using System;
using System.Collections.Generic;
using System.Text;

namespace CompisitePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            return this.Price;
        }
    }
}
