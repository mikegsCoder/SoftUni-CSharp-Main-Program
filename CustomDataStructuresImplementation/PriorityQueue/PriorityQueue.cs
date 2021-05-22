namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;
        public PriorityQueue()
        {
            this.heap = new List<T>();
        }
        public int Size { get { return this.heap.Count; } }

        public void Add(T element)
        {
            this.heap.Add(element);
            this.HeapifyUp(this.Size - 1);
        }
        private void HeapifyUp(int index)
        {
            while (index > 0 && IsLess(Parent(index), index))
            {
                this.Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private bool IsLess(int a, int b)
        {
            return this.heap[a].CompareTo(this.heap[b]) < 0;
        }
        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }
        public T Peek()
        {
            if (this.Size <= 0)
            {
                throw new InvalidOperationException();
            }

            return this.heap[0];
        }
        public T Dequeue()
        {
            if (this.Size <= 0)
            {
                throw new InvalidOperationException();
            }

            T item = this.heap[0];

            this.Swap(0, this.Size - 1);
            this.heap.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return item;
        }

        private void HeapifyDown(int index)
        {
            while(Left(index) < this.Size && IsLess(index, Left(index)))
            {
                int child = Left(index);
                int rightChildIndex = Right(index);

                if(rightChildIndex < this.Size && IsLess(child,rightChildIndex))
                {
                    child = rightChildIndex;
                }

                this.Swap(index, child);
                index = child;
            }
        }

        private static int Left(int index)
        {
            return 2 * index + 1;
        }

        private static int Right(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            T temp = this.heap[a];
            this.heap[a] = this.heap[b];
            this.heap[b] = temp;
        }
    }
}
