using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var n = int.Parse(numbers[0]);
            var m = int.Parse(numbers[1]);
            var firstSet = new List<int>();
            var secondSet = new List<int>();
           

            for (int i = 0; i < n + m; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSet.Add(number);

                }
                else
                {
                    secondSet.Add(number);
                }
            }

            
            Console.WriteLine(string.Join(" ", firstSet.Intersect(secondSet)));
        }
    }
}
