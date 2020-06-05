using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {

        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new List<Tire>()
            {
            new Tire(tire1Pressure,tire1Age),
            new Tire(tire2Pressure,tire2Age),
            new Tire(tire3Pressure,tire3Age),
            new Tire(tire4Pressure,tire4Age),
            };
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            private set { this.cargo = value; }
        }


        public List<Tire> Tires
        {
            get { return this.tires; }
            private set { this.tires = value; }
        }

        public override string ToString()
        {
            return this.Model;
        }

    }
}
