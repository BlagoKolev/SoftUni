using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIR_CONDITION_CONCUMPTION = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            set { base.FuelConsumption = value + TRUCK_AIR_CONDITION_CONCUMPTION; }
        }
        public override string ToString()
        {
            return string.Format($"{this.GetType().Name}: {this.FuelQuantity:f2}");
        }
        public override void Refuel(double fuelAmount)
        {
           Math.Round( this.FuelQuantity += fuelAmount * 0.95);
        }
    }
}

