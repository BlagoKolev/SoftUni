using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double travelledDistance = 0;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            private set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKm
        {
            get { return this.fuelConsumptionPerKm; }
            private set { this.fuelConsumptionPerKm = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public void Move(double kilometers)
        {
            var neededFuel = this.fuelConsumptionPerKm * kilometers;

            if (this.FuelAmount >= neededFuel)
            {
                this.FuelAmount -= neededFuel;
                this.TravelledDistance += kilometers;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(string.Concat(this.Model + ' ' + this.FuelAmount + ' ' + this.FuelConsumptionPerKm));
            return sb.ToString();
        }
    }
}
