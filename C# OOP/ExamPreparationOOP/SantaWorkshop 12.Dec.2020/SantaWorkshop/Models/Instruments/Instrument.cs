using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int DECREASE_IN_USE = 10;
        private int power;
        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get { return this.power; }
            private set
            { this.power = value < 0 ? value = 0 : value; }
        }

        public bool IsBroken()
        {
            return this.Power <= 0;
        }

        public void Use()
        {
            this.Power -= DECREASE_IN_USE;
        }
    }
}
