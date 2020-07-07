using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        { }
              
        public override double FuelConsumption 
        {
            get { return base.FuelConsumption; }
            set { base.FuelConsumption = value + AIR_CONDITION_CONSUMPTION; }
        }
                      
        public override string ToString()
        {
            return string.Format($"{this.GetType().Name}: {this.FuelQuantity:f2}"); 
        }
    }
}
