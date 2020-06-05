using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<Person> GetMembersOlderThan30()
        {
            var olderThan30 = this.Members.Where(x => x.Age > 30).ToList();
            return olderThan30;
        }
    }
}
