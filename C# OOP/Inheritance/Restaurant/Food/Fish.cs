using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Food
{
    public class Fish : MainDish
    {
        private const double FishGrams = 22;

        public Fish(string name, decimal price)
            : base(name, price, FishGrams)
        {

        }
    }
}
