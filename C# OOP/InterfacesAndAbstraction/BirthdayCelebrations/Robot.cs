using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IIdentificable
    {
        public Robot(string name, string iD)
        {
            this.Name = name;
            this.ID = iD;
        }

        public string Name { get;private set; }
        public string ID { get;private set; }
    }
}
