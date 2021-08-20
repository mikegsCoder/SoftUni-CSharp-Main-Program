using System;

namespace ProjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {            
            string architectName = Console.ReadLine();
            int projectCount = int.Parse(Console.ReadLine());

            int projectLenght = projectCount * 3;

            Console.WriteLine($"The architect {architectName} will need {projectLenght} hours to complete {projectCount} project/s.");
        }
    }
}
