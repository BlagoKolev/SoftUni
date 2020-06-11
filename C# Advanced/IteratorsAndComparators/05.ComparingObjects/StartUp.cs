using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                var name = input[0];
                var age = int.Parse(input[1]);
                var town = input[2];
                var person = new Person(name, age, town);
                persons.Add(person);
            }
            var personID = int.Parse(Console.ReadLine());
            var personIndex = personID - 1;
            var equalsCount = 0;


            for (int i = 0; i < persons.Count; i++)
            {
                var currentPerson = persons[i];

                if (persons[personIndex].CompareTo(currentPerson) == 0)
                {
                    equalsCount++;
                }
            }
            var diffCount = persons.Count - equalsCount;
            if (equalsCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", equalsCount, diffCount, persons.Count);
            }

        }
    }
}
