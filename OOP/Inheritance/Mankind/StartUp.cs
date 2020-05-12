using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var studentArgs = ReadInputFromConsole();
                var workerArgs = ReadInputFromConsole();

                var studentFirstName = studentArgs[0];
                var studentLastName = studentArgs[1];
                var studentFacNumber = studentArgs[2];

                var student = new Student(studentFirstName, studentLastName, studentFacNumber);

                var workerFirstName = workerArgs[0];
                var workerLastName = workerArgs[1];
                var weekSalary = decimal.Parse(workerArgs[2]);
                var hoursPerDay = double.Parse(workerArgs[3]);

                var worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        public static string[] ReadInputFromConsole()
        {
            var input = Console.ReadLine().Split().ToArray();
            return input;

        }
    }
}
