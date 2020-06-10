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
            var myList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                myList.Add(input);

            }
            var box = new Box<string>();
            var elementTocompare = Console.ReadLine();


            Console.WriteLine(box.FindBiggerElements(myList, elementTocompare));

        }
    }
}
