using System;

namespace P02.ImplementingCustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] array;

        public CustomStack()
        {
            this.array = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            this.Validate();
            int element = this.array[this.Count - 1];
            this.array[this.Count - 1] = default;
            this.Count--;

            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        public int Peek()
        {
            this.Validate();
            return this.array[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.array[i]);
            }
        }

        public void MySelect(Func<int, int> func)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.array[i] = func(this.array[i]);
            }
        }

        private void Validate()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];
            Array.Copy(this.array, copy, this.Count);
            this.array = copy;
        }

        private void Resize()
        {
            int[] copy = new int[this.array.Length * 2];
            Array.Copy(this.array, copy, this.Count);
            this.array = copy;
        }
    }
}
