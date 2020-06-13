using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public int CompareTo(Person other)
        {
            var result = 1;
            if (other != null)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Age.CompareTo(other.Age);
                }
            }
           
            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            return (this.Name == other.Name && this.Age == other.Age);

        }

        public override int GetHashCode()
        {
            var hash = this.Name.GetHashCode() + this.Age.GetHashCode();
            return hash;
        }
    }
}
