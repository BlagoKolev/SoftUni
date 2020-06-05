using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int? displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacemnt, string efficiency)
            : this(model, power, displacemnt)
        {
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public int Power
        {
            get { return this.power; }
            private set { this.power = value; }
        }

        public int? Displacement
        {
            get { return this.displacement; }
            private set { this.displacement = value; }
        }


        public string Efficiency
        {
            get { return this.efficiency; }
            private set { this.efficiency = value; }
        }


    }
}
