using System;

namespace _07.ImplementingCustomDataStructures_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);

            myList.RemoveAt(1);            
            myList.RemoveAt(1);            
            myList.RemoveAt(1);            
        }
    }
}
