using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
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
            IInstrument instrument = null;
            while (dwarf.Energy > 0 && dwarf.Instruments.Any(x => x.Power > 0))
            {
                instrument = dwarf.Instruments.FirstOrDefault(x => x.Power > 0);

                while (!present.IsDone() && dwarf.Energy > 0 && !instrument.IsBroken())
                {
                    dwarf.Work();
                    instrument.Use();
                    present.GetCrafted();
                }

                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
