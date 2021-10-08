using System;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
