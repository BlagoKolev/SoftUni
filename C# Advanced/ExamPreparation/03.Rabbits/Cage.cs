using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private string name;
        private int capacity;
        private readonly List<Rabbit> rabbits;
        private int count;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.rabbits.Count; }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > this.rabbits.Count)
            {
                rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {

            var isRabbitExist = this.rabbits.Any(x => x.Name == name);
            if (isRabbitExist)
            {
                var rabbitToRemove = this.rabbits.Where(x => x.Name == name).FirstOrDefault();
                this.rabbits.Remove(rabbitToRemove);
            }
            return isRabbitExist;
           
        }

        public void RemoveSpecies(string species)
        {
            this.rabbits.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbitForSale = this.rabbits.Where(x => x.Name == name).FirstOrDefault();
            rabbitForSale.Available = false;
            return rabbitForSale;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitsForSale = new List<Rabbit>();

            foreach (var rabbit in this.rabbits)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    rabbitsForSale.Add(rabbit);
                }
            }
            return rabbitsForSale.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Rabbits available at {0}:", this.Name));
            foreach (var rabbit in this.rabbits.Where(x => x.Available == true))
            {
                sb.AppendLine(string.Format("{0}", rabbit));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
