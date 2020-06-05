using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure
        {
            get { return this.pressure; }
            private set { this.pressure = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}
