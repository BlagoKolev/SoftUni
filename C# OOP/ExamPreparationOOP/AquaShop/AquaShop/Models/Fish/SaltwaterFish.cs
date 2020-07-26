using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int FISH_SIZE = 5;
        public SaltwaterFish(string name, string species, decimal price)
            :base(name,species,price)
        {
            this.Size = FISH_SIZE;
        }
        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
