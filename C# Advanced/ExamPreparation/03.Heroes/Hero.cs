﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }



        public Item Item
        {
            get { return this.item; }
            private set { this.item = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("Hero: {0} - {1}lvl", this.Name, this.Level))
                .AppendLine(string.Format("{0}", this.item));
            return sb.ToString().TrimEnd();
        }
    }
}
