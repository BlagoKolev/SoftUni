using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                var box = new Box<int>(number);
                Console.WriteLine(box);
            }
        }
    }
}
