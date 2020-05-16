namespace BirthdayCelebrations
{
    public class Pet : Unit, IIdentity
    {
        public Pet(string name, string birthdate)
            : base(name, birthdate)
        {
        }

    }
}
