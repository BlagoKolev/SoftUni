using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int ENERGY_FOR_WORKING = 10;
        private const int HAPPY_DWARF_ENERGY = 100;

        public HappyDwarf(string name) : base(name, HAPPY_DWARF_ENERGY)
        {

        }
        public override void Work()
        {
            this.Energy -= ENERGY_FOR_WORKING;
        }
    }
}
