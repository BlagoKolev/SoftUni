using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.members; }
            private set { this.members = value; }
        }

        public void AddMember(Person person)
        {
            this.Members.Add(person);
        }

        public Person GetOldestMember()
        {
            var oldestMember = this.Members.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
