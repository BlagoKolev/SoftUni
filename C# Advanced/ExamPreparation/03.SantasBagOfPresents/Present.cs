using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Present
    {
        private string name;
        private double weight;
        private string gender;

        public Present(string name, double weight, string gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public string Gender
        {
            get { return this.gender; }
            private set { this.gender = value; }
        }

        public override string ToString()
        {
            return string.Format("Present {0} ({1}) for a {2}", this.Name
                , this.Weight
                , this.Gender);
        }
    }
}
