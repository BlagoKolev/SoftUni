namespace BorderControl
{
    public class Citizen : Unit
    {
        private string name;
        private int age;
        private int id;

        public Citizen(string name, int age, string id)
            : base(name, id)
        {
            this.Age = age;
        }

        
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

    }
}
