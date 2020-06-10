using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var myList = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                myList.Add(input);

            }
            var box = new Box<double>();
            var elementTocompare = double.Parse(Console.ReadLine());


            Console.WriteLine(box.FindBiggerElements(myList, elementTocompare));

        }
    }
}

