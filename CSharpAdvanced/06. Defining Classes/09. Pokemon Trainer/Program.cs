using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {            
            Dictionary<Trainer, List<Pokemon>> trainers = new Dictionary<Trainer, List<Pokemon>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] currentInput = input.Split();
                string currTrainerName = currentInput[0];
                string currPokemonName = currentInput[1];
                string currPokemonElement = currentInput[2];
                int currPokemonHealth = int.Parse(currentInput[3]);

                Trainer currTrainer = new Trainer(currTrainerName, 0);
                Pokemon currPokemon = new Pokemon(currPokemonName, currPokemonElement, currPokemonHealth);

                bool newTraner = true;
                foreach (var trainer in trainers)
                {
                    if (trainer.Key.Name == currTrainerName)
                    {
                        newTraner = false;
                    }
                }

                if (newTraner)
                {
                    trainers.Add(currTrainer, new List<Pokemon>());
                }

                foreach (var trainer in trainers.Where(t => t.Key.Name == currTrainerName))
                {
                    trainer.Value.Add(currPokemon);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool receivedBage = false;
                    foreach (var pokemon in trainer.Value)
                    {
                        if (pokemon.Element == input && !receivedBage)
                        {
                            trainer.Key.NumberOfBages++;
                            receivedBage = true;
                        }
                    }

                    if (!receivedBage)
                    {
                        foreach (var pokemon in trainer.Value)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    for (int i = trainer.Value.Count-1 ; i >=0 ; i--)
                    {
                        if (trainer.Value[i].Health <= 0)
                        {
                            trainer.Value.RemoveAt(i);
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Key.NumberOfBages))
            {
                Console.WriteLine($"{trainer.Key.Name} {trainer.Key.NumberOfBages} {trainer.Value.Count}");
            }
        }
    }
}
