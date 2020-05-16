
namespace PersonInfo
{
    public class Citizen : IIdentifiable, IBirthable, IPerson
    {
        private string birthdate;
        private string id;
        private string name;
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
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

        public string Birthdate
        {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }
    }
}
