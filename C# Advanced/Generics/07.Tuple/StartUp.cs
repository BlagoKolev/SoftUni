using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {


            var input = Console.ReadLine().Split();
            var fullName = input[0] + ' '  + input[1];
            var adress = input[2];
            var tuple = new Tuple<string, string>(fullName, adress);
            Console.WriteLine(tuple);

            var input2 = Console.ReadLine().Split();
            var name = input2[0];
            var beer = int.Parse(input2[1]);
            var tuple2 = new Tuple<string, int>(name, beer);
            Console.WriteLine(tuple2);

            var input3 = Console.ReadLine().Split();
            var integer = int.Parse(input3[0]);
            var doublee = double.Parse(input3[1]);
            var tuple3 = new Tuple<int, double>(integer, doublee);
            Console.WriteLine(tuple3);
        }
    }
}