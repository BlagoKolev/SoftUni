using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public string Drive(double distance)
        {
            var neededFuel = this.FuelConsumption * distance;
            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return string.Format($"{this.GetType().Name} travelled {distance} km");
            }
            return string.Format($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }

    }
}
