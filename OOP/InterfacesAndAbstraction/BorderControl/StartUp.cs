using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var units = new HashSet<Unit>();

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
                    var citizen = new Citizen(name, age, id);
                    units.Add(citizen);
                }
                else if (command.Length == 2)
                {
                    var name = command[0];
                    var id = command[1];
                    var robot = new Robot(name, id);
                    units.Add(robot);
                }
            }
            var fakeNum = Console.ReadLine();

            var fakeUnits = units.Where(x => x.Id.EndsWith(fakeNum)).ToArray();
            foreach (var unit in fakeUnits)
            {
                Console.WriteLine(unit.Id);
            }
        }
    }
}
