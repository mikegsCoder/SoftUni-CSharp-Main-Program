using System;
using System.Collections.Generic;
using System.Text;

namespace CompisitePattern
{
    public class Composite : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> giftBases;

        public Composite(string name, decimal price) 
            : base(name, price)
        {
            this.giftBases = new List<GiftBase>();
        }

        public void Add(GiftBase giftBase)
        {
            this.giftBases.Add(giftBase);
        }

        public bool Remove(GiftBase giftBase)
        {
            return this.giftBases.Remove(giftBase);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (GiftBase giftBase in this.giftBases)
            {
                totalPrice += giftBase.Price;
            }

            return totalPrice;
        }
    }
}
