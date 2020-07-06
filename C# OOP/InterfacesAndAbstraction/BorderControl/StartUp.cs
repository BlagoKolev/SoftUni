using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var members = new List<IIdenticable>();

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }
                if (command.Length == 3)
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var id = command[2];
                    IIdenticable member = new Citizen(name, age,id);
                    members.Add(member);
                }
                else
                {
                    var model = command[0];
                    var id = command[1];
                    IIdenticable member = new Robot(model, id);
                    members.Add(member);
                }
               
            }
            var fakeId = Console.ReadLine();

            foreach (var member in members)
            {
                if (member.ID.EndsWith(fakeId))
                {
                    Console.WriteLine(member.ID);
                }
            }
        }
    }
}
