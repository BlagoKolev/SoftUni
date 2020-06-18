using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private readonly List<Present> bag;
        private string color;
        private int capacity;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.bag = new List<Present>();
        }

        public string Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.bag.Count; }
        }

        public void Add(Present present)
        {
            if (this.bag.Count < this.Capacity)
            {
                this.bag.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var isPresentExist = this.bag.Any(x => x.Name == name);
            if (isPresentExist)
            {
                var presentToRemove = this.bag.Where(x => x.Name == name).FirstOrDefault();
                this.bag.Remove(presentToRemove);
            }
            return isPresentExist;
        }

        public Present GetHeaviestPresent()
        {
            return this.bag.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return this.bag.Where(x => x.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} bag contains:", this.Color));

            foreach (var present in this.bag)
            {
                sb.AppendLine(string.Format("{0}", present));
            }
            return sb.ToString().TrimEnd();
        }


    }
}
