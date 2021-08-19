using P04WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> preferredFoods =>
            new List<Type>() { typeof(Vegetable) ,typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
