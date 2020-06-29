﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Person
{
    public class Person
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
            set { this.name = value; }
        }

        public virtual int Age
        {
            get { return this.age; }
           protected set
            {
                if (value<0)
                {
                   this.age = 0;
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));
            return sb.ToString().TrimEnd();
        }

    }
}
