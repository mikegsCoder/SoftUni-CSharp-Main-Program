using P04WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> preferredFoods => 
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
