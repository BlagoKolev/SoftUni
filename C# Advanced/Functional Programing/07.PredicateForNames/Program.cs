using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .Where(x => x.Length <= n)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
