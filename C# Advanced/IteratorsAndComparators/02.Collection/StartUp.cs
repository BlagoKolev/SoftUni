using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = null;
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    return;
                }

                if (input[0] == "Create")
                {
                    if (input.Length == 1)
                    {
                        iterator = new ListyIterator<string>();
                    }
                    else
                    {
                        var listArgs = input.Skip(1).ToArray();
                        iterator = new ListyIterator<string>(listArgs);
                    }
                }

                else if (input[0] == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (input[0] == "Print")
                {
                    iterator.Print();
                }
                else if (input[0] == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
                else if (input[0] == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", iterator));
                }
            }
        }
    }
}
