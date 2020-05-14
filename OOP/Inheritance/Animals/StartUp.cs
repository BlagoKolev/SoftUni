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

            while (true)
            {
                try
                {
                    var animalType = Console.ReadLine();
                    if (animalType == "Beast!")
                    {
                        break;
                    }
                    var animalArgs = Console.ReadLine().Split();
                    var name = animalArgs[0];
                    var age = int.Parse(animalArgs[1]);
                    var gender = animalArgs[2];
                    switch (animalType)
                    {
                        case "Cat": animals.Add(new Cat(name, age, gender)); break;
                        case "Dog": animals.Add(new Dog(name, age, gender)); break;
                        case "Frog": animals.Add(new Frog(name, age, gender)); break;
                        case "Kitten": animals.Add(new Kitten(name, age)); break;
                        case "Tomcat": animals.Add(new Tomcat(name, age)); break;

                        default: throw new ArgumentException("Invalid input!");
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
            animals.ForEach(Console.WriteLine);
        }
    }
}
