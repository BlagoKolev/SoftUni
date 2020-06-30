using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        private double fuelConsumption;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption 
        { get => DefaultFuelConsumption; set => this.fuelConsumption = DefaultFuelConsumption; }
        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
