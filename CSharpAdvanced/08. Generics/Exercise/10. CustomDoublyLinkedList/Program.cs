using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(2);
            list.AddLast(5);
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
