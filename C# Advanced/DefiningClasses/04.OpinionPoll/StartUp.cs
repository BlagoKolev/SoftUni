using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            var olderThan30 = family.GetMembersOlderThan30().OrderBy(x => x.Name);
            Console.WriteLine(string.Join(Environment.NewLine,
                olderThan30));
        }
    }
}
