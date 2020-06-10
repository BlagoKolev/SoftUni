using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                strings.Add(input);
            }
            var box = new Box<string>(strings);

            var inputIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = inputIndexes[0];
            var index2 = inputIndexes[1];
            var output = box.SwapElements(strings, index1, index2);


            Console.WriteLine(box);
        }

    }
}
