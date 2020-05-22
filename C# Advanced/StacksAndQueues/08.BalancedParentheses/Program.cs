using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var myStack = new Stack<char>();


            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];
                if (currentSymbol == '[' || currentSymbol == '{' || currentSymbol == '(')
                {
                    myStack.Push(currentSymbol);
                }
                else
                {
                    if (currentSymbol == ')')
                    {
                        if (myStack.Pop() == '(')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                    }

                    if (currentSymbol == '}')
                    {
                        if (myStack.Pop() == '{')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    if (currentSymbol == ']')
                    {
                        if (myStack.Pop() == '[')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
