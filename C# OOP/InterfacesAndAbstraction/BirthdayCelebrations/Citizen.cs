using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IBirthable, IIdentificable
    {
        public Citizen(string name, int age, string iD, string birthdate)
        {
            this.Name = name;
           this.Age = age;
           this.ID = iD;
           this.Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID { get; private set; }
        public string Birthdate { get; private set; }
    }
}
