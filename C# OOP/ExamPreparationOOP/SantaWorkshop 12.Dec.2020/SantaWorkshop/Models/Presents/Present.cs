using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private const int ENERGY_FOR_CRAFTING = 10;
        private string name;
        private int energyRequired;
        public Present(string name, int energyRequired)
        {
            this.EnergyRequired = energyRequired;
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set { this.energyRequired = value < 0 ? 0 : value; }
        }

        public void GetCrafted()
        {
            this.energyRequired -= ENERGY_FOR_CRAFTING;
        }

        public bool IsDone()
        {
            return this.energyRequired <= 0;
        }
    }
}
