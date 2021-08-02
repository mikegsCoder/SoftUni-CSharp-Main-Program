using System;

namespace _07.ImplementingLinkedLists_Lab
{
    class SoftUniLinkedListFastReverse
    {
        private int count = 0;

        private bool reversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void Reverse()
        {
            var Temp = Head;
            Head = Tail;
            Tail = Temp;
            reversed = !reversed;
        }
        public void ForEach(Action<Node> action)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode);

                if (reversed)
                {
                    currentNode = currentNode.Previous;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }
        public void AddLast(Node node)
        {
            count++;
            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }
    }
}
