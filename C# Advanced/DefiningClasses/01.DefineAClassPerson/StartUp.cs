using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age =int.Parse(Console.ReadLine());
            var person = new Person();
            person.Name = name;
            person.Age = age;
            Console.WriteLine($"{person.Name} {person.Age}");
            
        }
    }
}
