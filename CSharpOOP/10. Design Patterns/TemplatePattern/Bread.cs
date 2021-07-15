using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();
        public abstract void Slice();
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
