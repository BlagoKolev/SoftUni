using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdenticable
    {
        public Citizen(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }

        public string ID { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }


    }
}
