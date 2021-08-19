using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        List<T> elements;
        public Box()
        {
            this.elements = new List<T>();
        }

        public int Count 
        { 
            get 
            { 
                return elements.Count; 
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            T removedElement = elements[elements.Count-1];
            elements.RemoveAt(elements.Count-1);
            return removedElement;
        }
    }
}
