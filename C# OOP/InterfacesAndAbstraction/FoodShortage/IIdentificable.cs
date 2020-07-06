using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IIdentificable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
