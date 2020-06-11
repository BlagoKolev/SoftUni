using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myStack = new CustomStack<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { ',', ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "Push")
                {
                    var elements = input.Skip(1).ToArray();
                    myStack.Push(elements);
                }
                else if (input[0] == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
            }

            if (myStack.MyCustomStack.Count > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (var element in myStack)
                    {
                        Console.WriteLine(element);
                    }
                }
            }

        }
    }
}
