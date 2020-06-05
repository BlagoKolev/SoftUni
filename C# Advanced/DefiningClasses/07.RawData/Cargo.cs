using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
        public int Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

    }
}
