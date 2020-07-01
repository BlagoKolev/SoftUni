using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ERROR_MESSAGE = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new Exception(ERROR_MESSAGE);
                }
                this.name = value;
            }
        }



        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new Exception(ERROR_MESSAGE);
                }
                this.age = value;
            }
        }



        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new Exception(ERROR_MESSAGE);
                }
                this.gender = value;
            }
        }


        public abstract string ProduceSound();


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}", this.GetType().Name))
            .AppendLine(string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender))
            .AppendLine(string.Format("{0}", this.ProduceSound()));
            return sb.ToString().TrimEnd();
        }
    }
}
