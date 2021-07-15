using P04WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
