using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            var currentInstrument = dwarf.Instruments.FirstOrDefault(x => x.Power > 0);

            while (dwarf.Energy > 0 && dwarf.Instruments.Any(x => x.Power > 0))
            {

                dwarf.Work();
                currentInstrument.Use();
                present.GetCrafted();

                if (currentInstrument.IsBroken())
                {
                    currentInstrument = dwarf.Instruments.FirstOrDefault(x => x.Power > 0);
                }
                if (present.IsDone())
                {
                    break;
                }

            }
        }
    }
}
