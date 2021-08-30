using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int ornamentComfort = 1;
        private const decimal ornamentPrice = 5;

        public Ornament() 
            : base(ornamentComfort, ornamentPrice)
        {
        }
    }
}
