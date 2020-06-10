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
            var numbers = new List<int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                numbers.Add(input);
            }
            var box = new Box<int>(numbers);

            var inputIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = inputIndexes[0];
            var index2 = inputIndexes[1];
            var output = box.SwapElements(numbers, index1, index2);


            Console.WriteLine(box);
        }

    }
}
