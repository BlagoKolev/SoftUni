using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public string Make
        {
            get { return this.make; }
            private set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set { this.horsePower = value; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set { this.registrationNumber = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Make: {0}", this.Make))
                .AppendLine(String.Format("Model: {0}", this.Model))
                .AppendLine(String.Format("HorsePower: {0}", this.HorsePower))
                .AppendLine(string.Format("RegistrationNumber: {0}", this.RegistrationNumber));

            return sb.ToString().TrimEnd();


        }
    }
}
