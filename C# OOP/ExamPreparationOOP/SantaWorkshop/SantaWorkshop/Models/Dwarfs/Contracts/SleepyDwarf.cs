using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs.Contracts
{
    public class SleepyDwarf : Dwarf
    {
        private const int SLEEPY_DWARF_ENERGY = 50;

        public SleepyDwarf(string name):base(name,SLEEPY_DWARF_ENERGY)
        {

        }

        public override void Work()
        {
            base.Energy -= 15;
        }
    }
}
