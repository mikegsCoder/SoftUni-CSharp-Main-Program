using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int bulletsShot = 0;

            int priceOfBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligence = int.Parse(Console.ReadLine());

            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currentBullet = bullets.Pop();
                counter++;
                bulletsShot++;

                if (currentBullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counter == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }
            
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - priceOfBullet*bulletsShot}");
            }
        }
    }
}
