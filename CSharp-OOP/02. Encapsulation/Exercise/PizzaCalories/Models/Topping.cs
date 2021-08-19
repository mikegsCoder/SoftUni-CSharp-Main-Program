using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 50;
       
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType 
        { 
            get => this.toppingType;
            private set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidToppingExcMsg, value));
                }

                this.toppingType = value;
            }
        }
        public int Weight 
        { 
            get => this.weight;
            private set 
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(String.Format
                        (GlobalConstants.InvalidToppingWeightExcMsg, value, MIN_WEIGHT, MAX_WEIGHT));
                }

                this.weight = value;
            }
        }
        internal double CalculateToppingCalories()
        {
            double typeModifier;

            if (this.ToppingType.ToLower() == "meat")
            {
                typeModifier = 1.2;
            }
            else if (this.ToppingType.ToLower() == "veggies")
            {
                typeModifier = 0.8;
            }
            else if (this.ToppingType.ToLower() == "cheese")
            {
                typeModifier = 1.1;
            }
            else
            {
                typeModifier = 0.9;
            }

            return (2 * this.Weight) * typeModifier;
        }
    }
}
