using System;
using System.Text;

namespace Person
{
    public class Child : Person
    {

        private int age;

        public Child(string name, int age)
            : base(name, age)
        {

        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return sb.ToString().TrimEnd();
        }

    }
}

