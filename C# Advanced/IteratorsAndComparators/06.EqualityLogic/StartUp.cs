using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedPerson = new SortedSet<Person>();
            var hashedPerson = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                sortedPerson.Add(person);
                hashedPerson.Add(person);
            }
            Console.WriteLine(sortedPerson.Count);
            Console.WriteLine(hashedPerson.Count);
        }
    }
}
