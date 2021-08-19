using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //
            SoftUniLinkedList<string> list = new SoftUniLinkedList<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                list.AddLast(new Node<string>(input));
            }

            list.ForEach(x => Console.WriteLine(x.Value));
        }
    }
}
