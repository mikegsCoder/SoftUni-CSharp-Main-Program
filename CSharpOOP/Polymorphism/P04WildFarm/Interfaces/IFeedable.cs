using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Interfaces
{
    public interface IFeedable
    {
        void Feed(IFood food);
        int FoodEaten { get; }
        double WeightMultiplier { get; }
        ICollection<Type> preferredFoods { get; }
    }
}
