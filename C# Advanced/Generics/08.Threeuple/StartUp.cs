using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split();
            var firstName = input1[0];
            var lastName = input1[1];
            var adress = input1[2];
            var town = input1[3];
            var fullName = firstName + ' ' + lastName;
            var threeuple1 = new Threeuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(threeuple1);

            var input2 = Console.ReadLine().Split();
            var name = input2[0];
            var litters = int.Parse(input2[1]);
            var condition = input2[2];
            bool isDrunk = false;
            if (condition == "drunk")
            {
                isDrunk = true;
            }

            var threeuple2 = new Threeuple<string, int, bool>(name, litters, isDrunk);
            Console.WriteLine(threeuple2);

            var input3 = Console.ReadLine().Split();
            var userName = input3[0];
            var ballance = double.Parse(input3[1]);
            var bankName = input3[2];
            var threeuple3 = new Threeuple<string, double, string>(userName, ballance, bankName);
            Console.WriteLine(threeuple3);
        }
    }
}
