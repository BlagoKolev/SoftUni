using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Beverages.HotBeverage
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;

        private double caffeine;

        public Coffee(string name, double caffein)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffein;
        }


        public double Caffeine
        {
            get { return this.caffeine; }
            set { this.caffeine = value; }
        }

    }
}
