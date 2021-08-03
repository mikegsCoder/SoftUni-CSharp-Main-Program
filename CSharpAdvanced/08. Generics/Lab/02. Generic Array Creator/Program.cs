using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {            
            int[] integers = ArrayCreator.Create(10, 33);
            string[] strings = ArrayCreator.Create(10, "pesho");
            Console.WriteLine(string.Join(' ',integers));
            Console.WriteLine(string.Join(' ',strings));
        }
    }
}
