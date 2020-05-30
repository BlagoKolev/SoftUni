using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            Predicate<int> funcPredicate = command == "odd" ?
                new Predicate<int>(x => x % 2 != 0) : new Predicate<int>(x => x % 2 == 0);

            var list = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (funcPredicate(i))
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(' ',list));
        }
    }
}
