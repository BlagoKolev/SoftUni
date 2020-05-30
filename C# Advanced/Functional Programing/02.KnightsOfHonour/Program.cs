using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonour
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(print);
                
                
        }
    }
}
