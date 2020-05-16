using FoodShortage.Intefaces;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer, IIdentifiable, IBirthable, IAge
    {
        private string id;
        private int age;
        private int food;
        private string name;
        private string birthdate;

        public Citizen(string name, string birthdate, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Food
        {
            get { return this.food; }
            private set { this.food = value; }
        }

        public int BuyFood()
        {
            return this.Food += 10;
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
        }
    }
}
