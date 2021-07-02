using System;

namespace DIContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class Named : Attribute
    {
        public Named(Type type)
        {
            this.TypeName = type;
        }

        public Type TypeName { get; set; }
    }
}
