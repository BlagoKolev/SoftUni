using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var subjects = new List<IBirthable>();
            IBirthable member = null;
            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Citizen":
                        var citizenName = command[1];
                        var age = int.Parse(command[2]);
                        var id = command[3];
                        var birthDate = command[4];
                        member = new Citizen(citizenName, age, id, birthDate);
                        subjects.Add(member);
                        break;

                    case "Pet":
                        var petName = command[1];
                        var petBirthDate = command[2];
                        member = new Pet(petName, petBirthDate);
                        subjects.Add(member);
                        break;
                }
                
            }
            var year = Console.ReadLine();
            foreach (var subj in subjects)
            {
                if (subj.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(subj.Birthdate);
                }
            }
        }
    }
}
