using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SLEEPY_DWARF_ENERGY = 50;
        private const int ENERGY_FOR_WORKING = 15;

        public SleepyDwarf(string name) : base(name,SLEEPY_DWARF_ENERGY)
        {

        }

        public override void Work()
        {
            this.Energy -= ENERGY_FOR_WORKING;
        }
    }
}
