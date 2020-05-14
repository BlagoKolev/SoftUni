using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender = "Female")
            : base(name, age, gender) { }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
