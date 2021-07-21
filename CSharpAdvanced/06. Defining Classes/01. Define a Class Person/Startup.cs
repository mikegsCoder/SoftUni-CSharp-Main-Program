using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person pesho = new Person();
            pesho.Name = "Pesho";
            pesho.Age = 20;

            Person gosho = new Person() { Name = "Gosho", Age = 18};
            
            Person stamat = new Person();
            stamat.Name = "Stamat";
            stamat.Age = 43;
        }
    }
}
