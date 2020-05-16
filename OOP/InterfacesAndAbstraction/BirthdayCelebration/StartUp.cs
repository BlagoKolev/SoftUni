using System;
using System.Collections.Generic;
using System.Linq;


namespace BirthdayCelebrations
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var units = new List<Unit>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                switch (input[0])
                {
                    case "Citizen":
                        var name = input[1];
                        var age = int.Parse(input[2]);
                        var id = input[3];
                        var birthdate = input[4];
                        units.Add(new Citizen(name, birthdate, id, age));
                        break;

                    case "Pet":
                        var petName = input[1];
                        var petBirthdate = input[2];
                        units.Add(new Pet(petName, petBirthdate));
                        break;

                    case "Robot":
                        var model = input[1];
                        var robotId = input[2];
                        break;
                }

            }
            var year = Console.ReadLine();
            foreach (var unit in units.Where(x => x.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(unit.Birthdate);
            }
        }
    }
}
