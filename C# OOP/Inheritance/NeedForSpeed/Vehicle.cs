using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private double DefaultFuelConsumption = 1.25;
        private double fuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
            set { this.fuelConsumption = this.DefaultFuelConsumption; }
        }

        public double Fuel { get; set; }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
