using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class GlobalConstants
    {
        public const string InvalidDoughExcMsg = "Invalid type of dough.";
        public const string InvalidDougWeighthExcMsg = "Dough weight should be in the range [{0}..{1}].";
        public const string InvalidToppingExcMsg = "Cannot place {0} on top of your pizza.";
        public const string InvalidToppingWeightExcMsg = "{0} weight should be in the range [{1}..{2}].";
        public const string InvalidPizzaNameExcMsg = "Pizza name should be between {0} and {1} symbols.";        
    }
}
