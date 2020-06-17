namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool available = true;
        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Species
        {
            get { return this.species; }
            private set { this.species = value; }
        }

        public bool Available
        {
            get { return this.available; }
            set { this.available = value; }
        }

        public override string ToString()
        {
            return string.Format("Rabbit ({0}): {1}", this.Species, this.Name);
        }
    }
}
