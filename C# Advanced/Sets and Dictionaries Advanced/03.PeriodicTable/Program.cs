using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var listOfElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    listOfElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", listOfElements));
        }
    }
}
