namespace BirthdayCelebrations
{
    public class Citizen : Unit, IIdentity, IId
    {
        private string id;
        private int age;

        public Citizen(string name, string birthdate, string id, int age)
            : base(name, birthdate)
        {
            this.Id = id;
            this.Age = age;
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

    }
}
