using P04WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.35;

        public override ICollection<Type> preferredFoods => 
            new List<Type>() {typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
