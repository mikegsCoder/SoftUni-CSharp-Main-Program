using System;

namespace _07.ImplementingLinkedLists_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedListFastReverse list = new SoftUniLinkedListFastReverse();

            for (int i = 0; i < 10; i++)
            {
                list.AddLast(new Node(i+1));
            }

            list.ForEach(node => Console.WriteLine(node.Value));

            list.Reverse();

            list.ForEach(node => Console.WriteLine(node.Value));

            return;

            Node node = new Node(1);

            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            //linkedList.AddHead(new Node(1));
            //linkedList.AddHead(new Node(2));
            //linkedList.AddHead(new Node(3));
            //linkedList.AddHead(new Node(4));

            Console.WriteLine("Remove empty Head:" + linkedList.RemoveHead());

            for (int i = 0; i < 10; i++)
            {
                //linkedList.AddHead(new Node(i));
                linkedList.AddLast(new Node(i));
            }

            Console.WriteLine("Remove Head:" + linkedList.RemoveHead().Value);
            Console.WriteLine("Remove Head:" + linkedList.RemoveHead().Value);
            Console.WriteLine("Remove Head:" + linkedList.RemoveHead().Value);

            Console.WriteLine("Remove Tail:" + linkedList.RemoveTail().Value);
            Console.WriteLine("Remove Tail:" + linkedList.RemoveTail().Value);
            Console.WriteLine("Remove Tail:" + linkedList.RemoveTail().Value);

            //var currentNode = linkedList.Head;

            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}
              
            Console.WriteLine("ForEachFromHead :");
            linkedList.ForEachFromHead(node => Console.WriteLine($"From Action: {node.Value}"));

            Console.WriteLine("ForEachFromTail :");
            linkedList.ForEachFromTail(node => Console.WriteLine($"From Action: {node.Value}"));

            int[] linkedListAsArray = linkedList.ToArray();

            Console.Write("LinkedListAsArray: ");
            Console.WriteLine(string.Join(", ", linkedListAsArray));
        }
    }
}
