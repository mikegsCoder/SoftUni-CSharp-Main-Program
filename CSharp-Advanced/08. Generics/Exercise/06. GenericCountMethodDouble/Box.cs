using System;

namespace P06GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public T ValueToCompare { get; set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }

        public bool MyCompare(Box<T> box, T valueToCompare)
        {
            return box.Value.CompareTo(valueToCompare) > 0;
        }
    }
}
