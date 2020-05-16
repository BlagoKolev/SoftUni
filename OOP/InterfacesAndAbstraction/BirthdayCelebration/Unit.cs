namespace BirthdayCelebrations
{
    public class Unit
    {
        private string name;
        private string birthdate;

        public Unit(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
        }
    }
}
