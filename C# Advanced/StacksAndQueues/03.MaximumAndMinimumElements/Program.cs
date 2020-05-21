using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var action = input[0];
                var element = 0;
                if (input.Length > 1)
                {
                    element = input[1];
                }

                switch (action)
                {
                    case 1: myStack.Push(element); break;
                    case 2:
                        if (isStackFull(myStack))
                        {
                            myStack.Pop();
                        }
                        break;
                    case 3:
                        if (isStackFull(myStack))
                        {
                            Console.WriteLine(myStack.Max());
                        }
                        break;
                    case 4:
                        if (isStackFull(myStack))
                        {
                            Console.WriteLine(myStack.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", myStack));
        }
        public static bool isStackFull(Stack<int> myStack)
        {
            bool isFull = false;
            if (myStack.Count > 0)
            {
                isFull = true;
            }
            return isFull;
        }
    }
}
