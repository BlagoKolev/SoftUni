using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {

            if (aquariumType == "FreshwaterAquarium")
            {
                IAquarium aquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                IAquarium aquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            return string.Format($"Successfully added {aquariumType}.");
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                IDecoration decoration = new Ornament();
                this.decorations.Add(decoration);
            }
            else if (decorationType == "Plant")
            {
                IDecoration decoration = new Plant();
                this.decorations.Add(decoration);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDecoration);
            }

            return string.Format(OutputMessages.SuccessfullyAdded,decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                var currentAquarium = FindCurrentAquarium(aquariumName);

                if (currentAquarium.GetType().Name == "SaltwaterAquarium")
                {
                    return OutputMessages.UnsuitableWater;
                }
                else
                {
                    IFish fish = new FreshwaterFish(fishName, fishSpecies, price);
                    currentAquarium.AddFish(fish);
                    return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                var currentAquarium = FindCurrentAquarium(aquariumName);
                if (currentAquarium.GetType().Name == "FreshwaterAquarium")
                {
                    return OutputMessages.UnsuitableWater;
                }
                else
                {
                    IFish fish = new SaltwaterFish(fishName, fishSpecies, price);
                    currentAquarium.AddFish(fish);
                    return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var currentAquarium = FindCurrentAquarium(aquariumName);
            var decorationsPrice = currentAquarium.Decorations.Sum(x => x.Price);
            var fishPrice = currentAquarium.Fish.Sum(x => x.Price);
            var totalCalculatedPrice = decorationsPrice + fishPrice;

            return string.Format($"The value of Aquarium {aquariumName} is {totalCalculatedPrice}.");
        }

        public string FeedFish(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            currentAquarium.Feed();
            return $"Fish fed: {currentAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {

            if (!this.decorations.Models.Any(x=>x.GetType().Name == decorationType))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var currentAquarium = FindCurrentAquarium(aquariumName);
            var decoration = this.decorations.Models.FirstOrDefault(x => x.GetType().Name == decorationType);
            currentAquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
        private IAquarium FindCurrentAquarium(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            return currentAquarium;
        }
        private IDecoration GetDecorationOfCurrentType(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            return decoration;
        }
    }
}
