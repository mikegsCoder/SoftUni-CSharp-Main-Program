namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }
        public int Size { get { return this.elements.Count; } }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(element, this.elements.Count - 1);
        }

        private void HeapifyUp(T item, int index)
        {
            int parent = (index - 1) / 2;

            if (parent < 0)
            {
                return;
            }

            int compare = this.elements[parent].CompareTo(this.elements[index]);

            if (compare < 0)
            {
                this.Swap(parent, index);
                this.HeapifyUp(this.elements[parent], parent);
            }
        }

        private void Swap(int parent, int index)
        {
            T temp = this.elements[parent];
            this.elements[parent] = this.elements[index];
            this.elements[index] = temp;
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}
