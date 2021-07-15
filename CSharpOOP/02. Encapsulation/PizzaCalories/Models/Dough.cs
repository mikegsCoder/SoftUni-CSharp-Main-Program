using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 200;

        private string flourType;
        private string bakingTechnique;
        private int weght;
        public Dough()
        {

        }
        public Dough(string flourType, string bakingTechnique, int weight) : this()
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weght = weight;
        }
        public string FlourType 
        { 
            get => this.flourType;
            private set 
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExcMsg);
                }

                this.flourType = value;
            } 
        }
        public string BakingTechnique 
        { 
            get => this.bakingTechnique;
            private set 
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExcMsg);
                }

                this.bakingTechnique = value;
            }
        }
        public int Weght 
        { 
            get => this.weght;
            private set 
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidDougWeighthExcMsg, MIN_WEIGHT, MAX_WEIGHT));
                }

                this.weght = value;
            } 
        }
               
        internal double CalculateDoughCalories()
        {
            double typeModifier;
            double techniqueModifier;

            if (this.FlourType.ToLower() == "white")
            {
                typeModifier = 1.5;
            }
            else
            {
                typeModifier = 1.0;
            }

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                techniqueModifier = 1.1;
            }
            else
            {
                techniqueModifier = 1.0;
            }

            return (2 * this.Weght) * typeModifier * techniqueModifier;
        }
    }
}
