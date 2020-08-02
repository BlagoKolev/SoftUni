using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Repositories;
using SantaWorkshop.Models.Workshops;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private  DwarfRepository dwarfs;
        private  PresentRepository presents;
        
        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            switch (dwarfType)
            {
                case "HappyDwarf": dwarf = new HappyDwarf(dwarfName); break;
                case "SleepyDwarf": dwarf = new SleepyDwarf(dwarfName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            this.dwarfs.Add(dwarf);
            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var currentDwarf = this.dwarfs.Models.FirstOrDefault(x => x.Name == dwarfName);
            if (currentDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            var instrument = new Instrument(power);
            currentDwarf.AddInstrument(instrument);
            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var sortedDwarfs = this.dwarfs.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();
            if (sortedDwarfs.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            var workshop = new Workshop();
            var present = this.presents.Models.FirstOrDefault(x => x.Name == presentName);

            while (sortedDwarfs.Count>0)
            {
                var currentDwarf = sortedDwarfs.FirstOrDefault(x => x.Energy >= 50);

                workshop.Craft(present, currentDwarf);

               

                if (currentDwarf.Energy == 0)
                {
                    sortedDwarfs.Remove(currentDwarf);
                    this.dwarfs.Remove(currentDwarf);
                }
                if (!currentDwarf.Instruments.Any(x=>x.Power > 0))
                {
                    sortedDwarfs.Remove(currentDwarf);
                }
                if (present.IsDone())
                {
                    break;
                }

            }
            var outputMsg = present.IsDone() ? $"Present {presentName} is done." : $"Present {presentName} is not done.";
            return outputMsg;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var craftedPresents = 0;

            foreach (var present in this.presents.Models)
            {
                if (present.IsDone())
                {
                    craftedPresents++;
                }
            }

            sb.AppendLine($"{craftedPresents} presents are done!")
                .AppendLine("Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}")
.AppendLine($"Energy: {dwarf.Energy}");
                var unbrokenInstrumentsCount = dwarf.Instruments.Where(x => !x.IsBroken()).Count();
                sb.AppendLine($"Instruments: {unbrokenInstrumentsCount} not broken left");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
