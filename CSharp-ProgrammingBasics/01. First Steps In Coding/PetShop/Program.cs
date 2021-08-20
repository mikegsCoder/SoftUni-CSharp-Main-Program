using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {            
            int dogsCount = int.Parse(Console.ReadLine());
            int nonDogsCount = int.Parse(Console.ReadLine());

            double dogsFoodPrice = dogsCount * 2.50;
            double nonDogsFoodPrice = nonDogsCount * 4;
            double finalPrice = dogsFoodPrice + nonDogsFoodPrice;

            Console.WriteLine($"{finalPrice} lv.");
        }
    }
}
