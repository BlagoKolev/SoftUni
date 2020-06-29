using System;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person("name", 50);
            var person2 = new Person("name2", -2);
            var child = new Child("name2", 12);

            Console.WriteLine(person);
            Console.WriteLine(person2);
            Console.WriteLine(child);
        }
    }
}
