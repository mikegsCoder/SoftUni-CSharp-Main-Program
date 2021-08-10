using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            double elevatorCapacity = double.Parse(Console.ReadLine());

            if (elevatorCapacity > numberOfPeople)
            {
                Console.WriteLine("1");
            }
            else
            {
                double courses = Math.Ceiling(numberOfPeople / elevatorCapacity);
                Console.WriteLine(courses);
            }
        }
    }
}
