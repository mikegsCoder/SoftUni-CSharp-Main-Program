using System;
using System.Collections.Generic;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int MIN_NAME_LENGTH = 1;
        private const int MAX_NAME_LENGTH = 15;
        private const int MAX_NUMBER_OF_TOPPINGS = 10;
        private const string TOO_MUCH_TOPPINGS = "Number of toppings should be in range [0..10].";

        private string name;
      
        public Pizza()
        {
            this.Toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough) : this()
        {
            this.Name = name;
            this.Dough = dough;
        }
        public string Name 
        { 
            get => this.name;
            set 
            {
                if (value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
                {
                    throw new ArgumentException(String.Format
                        (GlobalConstants.InvalidPizzaNameExcMsg,MIN_NAME_LENGTH,MAX_NAME_LENGTH));
                }

                this.name = value;
            }
        }
        public Dough Dough { get; set; }
        public ICollection<Topping> Toppings { get; set; }

        public override string ToString()
        {
            if (this.Toppings.Count > MAX_NUMBER_OF_TOPPINGS)
            {
                throw new ArgumentException(TOO_MUCH_TOPPINGS);
            }

            return $"{this.Name} - {this.CalculatePizzaCalories():f2} Calories.";
        }
        private double CalculatePizzaCalories()
        {
            double calories = this.Dough.CalculateDoughCalories();

            foreach (Topping topping in Toppings)
            {
                calories += topping.CalculateToppingCalories();
            }

            return calories;
        }
    }
}
