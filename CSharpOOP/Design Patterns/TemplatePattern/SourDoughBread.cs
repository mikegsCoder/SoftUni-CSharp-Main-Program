using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    class SourDoughBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking for 30 minutes.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredients for SourDough bread."); ;
        }

        public override void Slice()
        {
            Console.WriteLine("Slice on four parts.");
        }
    }
}
