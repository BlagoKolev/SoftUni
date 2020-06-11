using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndcomparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ',', ' ' }
                , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
