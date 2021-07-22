using System;

namespace P02.ImplementingCustomStack
{
    class Program
    {
        static void Main(string[] args)
        {            
            CustomStack myStack = new CustomStack();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(40);
            myStack.Push(50);

            myStack.MySelect(x => x * 10);
            myStack.ForEach(x => Console.WriteLine(x));
        }
    }
}
