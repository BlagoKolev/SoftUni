using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs.Contracts
{
    public class HappyDwarf : Dwarf
    {
        private const int  HAPPY_DWARF_ENRG = 100;
        public HappyDwarf(string name):base(name,HAPPY_DWARF_ENRG)
        {

        }

        public override void Work()
        {
            base.Energy -= 10;
        }
    }
}
