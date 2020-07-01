using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Beverages.HotBeverage
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {

        }
    }
}
