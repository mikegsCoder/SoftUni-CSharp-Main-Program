using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Aquarium currentAquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                currentAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                currentAquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(currentAquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            Decoration currentDecoration = null;
            if (decorationType == "Ornament")
            {
                currentDecoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                currentDecoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(currentDecoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var currAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if ((fishType == "FreshwaterFish" && currAquarium.GetType().Name == "SaltwaterAquarium") ||
                (fishType == "SaltwaterFish" && currAquarium.GetType().Name == "FreshwaterAquarium"))
            {
                return OutputMessages.UnsuitableWater;
            }

            Fish currFish = null;

            if (fishType == "FreshwaterFish")
            {
                currFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            currAquarium.AddFish(currFish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var currAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal val = currAquarium.Fish.Sum(x => x.Price) + currAquarium.Decorations.Sum(y => y.Price);

            return String.Format(OutputMessages.AquariumValue, aquariumName, val.ToString("f2"));
        }

        public string FeedFish(string aquariumName)
        {
            var currAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in currAquarium.Fish)
            {
                fish.Eat();
            }

            return String.Format(OutputMessages.FishFed, currAquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var currDecoration = this.decorations.FindByType(decorationType);

            if (currDecoration == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var currAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            currAquarium.AddDecoration(currDecoration);
            this.decorations.Remove(currDecoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
