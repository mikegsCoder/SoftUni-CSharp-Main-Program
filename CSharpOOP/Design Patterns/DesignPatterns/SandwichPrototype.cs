using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public abstract class SandwichPrototype<T>
    {
        public abstract T ShallowCopy();
        public abstract T DeepCopy();
    }
}
