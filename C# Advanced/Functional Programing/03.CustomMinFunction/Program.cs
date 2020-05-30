using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> FindMinNumber = x =>
             {
                 var minValue = int.MaxValue;

                 foreach (var number in x)
                 {
                     if (number < minValue)
                     {
                         minValue = number;
                     }
                 }
                 return minValue;
             };

            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(FindMinNumber(array));

        }
    }
}
