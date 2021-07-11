using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PizzaCalories.Models;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public readonly Pizza pizza;
        public Engine()
        {
            this.pizza = new Pizza();
        }
        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string pizzaName;
                if (input[0] == "Pizza")
                {
                    pizzaName = input[1];
                    this.pizza.Name = pizzaName;
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cookingArgs = command.Split(' ');

                    if (cookingArgs[0] == "Dough")
                    {
                        string[] doughArgs = cookingArgs.Skip(1).ToArray();
                        Dough dough = this.CreateDough(doughArgs);
                        this.pizza.Dough = dough;
                    }
                    else if (cookingArgs[0] == "Topping")
                    {
                        string[] toppingArgs = cookingArgs.Skip(1).ToArray();
                        Topping topping = this.CreateTopping(toppingArgs);
                        this.pizza.Toppings.Add(topping);
                    }
                }

                Console.WriteLine(this.pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private Topping CreateTopping(string[] toppingArgs)
        {
            string toppingType = toppingArgs[0];
            int weirght = int.Parse(toppingArgs[1]);

            Topping topping = new Topping(toppingType, weirght);

            return topping;
        }

        private Dough CreateDough(string[] doughArgs)
        {
            string doughType = doughArgs[0];
            string techniqueType = doughArgs[1];
            int weight = int.Parse(doughArgs[2]);

            Dough dough = new Dough(doughType, techniqueType, weight);

            return dough;
        }
    }
}
