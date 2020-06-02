using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "Party!")
                {
                    break;
                }

                var commandType = command[0];
                var predicateArgs = command.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if (commandType == "Remove")
                {
                    names.RemoveAll(predicate);
                }

                else if (commandType == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        string currentName = names[i];

                        if (predicate(currentName))
                        {
                            names.Insert(i + 1, currentName);
                            i++;
                        }
                    }
                }
            }
            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine("{0} are going to the party!", string.Join(", ", names));
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            var predicateType = predicateArgs[0];
            var prdcArgs = predicateArgs[1];

            Predicate<string> predicate = null;

            if (predicateType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prdcArgs);
                });
            }
            else if (predicateType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prdcArgs);
                });
            }
            else if (predicateType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prdcArgs);
                });
            }

            return predicate;
        }
    }
}
