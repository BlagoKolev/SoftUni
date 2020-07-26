using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs.Contracts
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private readonly ICollection<IInstrument> instruments;

        public Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                this.energy = value < 0 ? 0 : value;
            }
        }


        public ICollection<IInstrument> Instruments
        {
            get { return this.instruments; }
        }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public abstract void Work();
        
       
    }
}
