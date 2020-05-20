using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elementsCount = input[0];
            var elementsToRemove = input[1];
            var searchedNumber = input[2];
            var numbersToPush = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var myStack = new Stack<int>();

            for (int i = 0; i < elementsCount; i++)
            {
                var currentNumber = numbersToPush[i];
                myStack.Push(currentNumber);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                if (myStack.Any())
                {
                    myStack.Pop();
                }
               

            }
            if (!myStack.Any())
            {
                Console.WriteLine(0);
                return;
            }
            if (myStack.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(myStack.Min());
            }




        }
    }
}
