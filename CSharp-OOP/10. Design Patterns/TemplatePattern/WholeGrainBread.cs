using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeGrainBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking 10 minutes."); ;
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing a lot of seeds.");
        }

        public override void Slice()
        {
            Console.WriteLine("Slice on two parts.");
        }
    }
}
