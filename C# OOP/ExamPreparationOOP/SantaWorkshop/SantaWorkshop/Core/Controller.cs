using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            var dwarf = CreateDwarfByType(dwarfType, dwarfName);
            this.dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarfs.Models.FirstOrDefault(x => x.Name == dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            IPresent present = this.presents.FindByName(presentName);



            ICollection<IDwarf> sortedDwarfs = this.dwarfs.Models.Where(x => x.Energy >= 0).OrderByDescending(x=>x.Energy).ToList();

            if (!sortedDwarfs.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            while (sortedDwarfs.Any())
            {
                var dwarfThatCraft = sortedDwarfs.FirstOrDefault();

                Workshop workshop = new Workshop();

                workshop.Craft(present, dwarfThatCraft);
                
                if (!dwarfThatCraft.Instruments.Any())
                {
                    sortedDwarfs.Remove(dwarfThatCraft);
                }

                if (dwarfThatCraft.Energy == 0)
                {
                    sortedDwarfs.Remove(dwarfThatCraft);
                    this.dwarfs.Remove(dwarfThatCraft);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
            var result = present.IsDone() ? string.Format(OutputMessages.PresentIsDone, presentName) : string.Format(OutputMessages.PresentIsNotDone, presentName);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var countCraftedPresents = 0;

            foreach (var present in this.presents.Models)
            {
                if (present.IsDone())
                {
                    countCraftedPresents++;
                }
            }
                      
            sb.AppendLine($"{countCraftedPresents} presents are done!")
                .AppendLine("Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}")
                    .AppendLine($"Energy: {dwarf.Energy}")
                .AppendLine($"Instruments: {dwarf.Instruments.Count} not broken left");
               
            }
            return sb.ToString().TrimEnd();
        }

        private IDwarf CreateDwarfByType(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            return dwarf;
        }
    }
}
