using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int daturaBombsCounter = 0;
            int cherryBombsCounter = 0;
            int smokeBombsCounter = 0;

            int currentEffect = 0;
            int currentCasing = 0;

            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (true)
            {
                if (currentEffect == 0 && effects.Count > 0)
                {
                    currentEffect = effects.Peek();
                }

                if (currentCasing == 0 && casings.Count > 0)
                {
                    currentCasing = casings.Peek();
                }

                if (currentEffect == 0 && effects.Count == 0)
                {
                    break;
                }

                if (currentCasing == 0 && casings.Count == 0)
                {
                    break;
                }

                if (currentEffect + currentCasing == 40)
                {
                    daturaBombsCounter++;
                    currentEffect = 0;
                    currentCasing = 0;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (currentEffect + currentCasing == 60)
                {
                    cherryBombsCounter++;
                    currentEffect = 0;
                    currentCasing = 0;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (currentEffect + currentCasing == 120)
                {
                    smokeBombsCounter++;
                    currentEffect = 0;
                    currentCasing = 0;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    casings.Pop();
                    currentCasing -= 5;
                    casings.Push(currentCasing);
                }

                if (daturaBombsCounter >= 3 && cherryBombsCounter >= 3 && smokeBombsCounter >= 3)
                {
                    break;
                }
            }

            if (daturaBombsCounter >= 3 && cherryBombsCounter >= 3 && smokeBombsCounter >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effects));
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casings));
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCounter}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombsCounter}");
        }
    }
}
