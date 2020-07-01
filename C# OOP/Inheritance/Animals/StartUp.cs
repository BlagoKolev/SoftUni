using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            Animal animal = null;

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }

                var animalArgs = Console.ReadLine().Split();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = animalArgs[2];

                try
                {
                    if (command == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }

                    else if (command == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (command == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (command == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (command == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                animals.Add(animal);
            }




            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
