using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer, IIdentificable
    {
        private string name;
        private int age;
        private int food = 0;

        public Citizen(string name, int age, string iD, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
            this.BirthDate = birthDate;
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

        public string ID { get; set; }

        public string BirthDate { get; set; }
        public int Food
        {
            get { return this.food; }
            set { this.food = value; }
        }


        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
