namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node<T>
            {
                Item = item,
                Next = this.head,
                Previous = null
            };

            Count++;
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }
            node.Next = head;
            head.Previous = node;
            head = node;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>
            {
                Item = item,
                Next = null,
                Previous = this.tail
            };

            Count++;

            if (tail == null)
            {
                head = node;
                tail = node;
                return;
            }

            node.Previous = tail;
            tail.Next = node;
            tail = node; 
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            Count--;

            var nodeToReturn = head;

            if (head.Next != null)
            {
                head = head.Next;
                head.Previous = null;
            }
            else
            {
                head = null;
                tail = null;
            }

            return nodeToReturn.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            
            Count--;

            var nodeToReturn = tail;

            if (tail.Previous != null)
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            else
            {
                tail = null;
                head = null;
            }

            return nodeToReturn.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private void EnsureNotEmpty()
        {
            if (this.Count == 0) throw new InvalidOperationException();
        }
        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Item);
                currentNode = currentNode.Next;
            }
        }
    }
}