using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer, IIdentificable
    {
        private string name;
        private int age;
        private int food = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Group { get; set; }
        public int Food
        {
            get { return this.food; }
            set { this.food = value; }
        }


        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
