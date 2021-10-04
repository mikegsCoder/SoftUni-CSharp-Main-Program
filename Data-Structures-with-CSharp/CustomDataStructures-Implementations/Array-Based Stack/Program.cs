using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Array_Based_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> arrStack = new ArrayStack<int>();

            for (int i = 1; i < 6; i++)
            {
                arrStack.Push(i);
            }

            Console.WriteLine(string.Join(", ",arrStack.ToArray()));
            Console.WriteLine("------------------------");
            Console.WriteLine($"ArrayStack Pop => {arrStack.Pop()}");
            Console.WriteLine($"ArrayStack Pop => {arrStack.Pop()}");
            Console.WriteLine("------------------------");
            Console.WriteLine(string.Join(", ", arrStack.ToArray()));

        }
    }
    class ArrayStack<T>
    {
        private T[] elements;
        private const int initialCapacity = 16;
        public ArrayStack(int capacity = initialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }
        public int Count { get; private set; }
        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                Array.Resize(ref elements, this.elements.Length * 2);
            }

            this.elements[this.Count] = element;
            this.Count++;
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            int lastIndex = this.Count - 1;
            T element = this.elements[lastIndex];
            this.elements[lastIndex] = default(T);
            this.Count--;

            return element;
        }
        public T[] ToArray()
        {
            LinkedList<T> list = new LinkedList<T>();

            for (int i = 0; i < this.Count; i++)
            {
                list.AddFirst(this.elements[i]);
            }

            return list.ToArray();
        }
    }
}
