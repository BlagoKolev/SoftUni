using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = ReadInput(Console.ReadLine());
            var females = ReadInput(Console.ReadLine());

            var maleStack = new Stack<int>(males);
            var femaleQueue = new Queue<int>(females);
            var matchesCount = 0;

            while (maleStack.Any() && femaleQueue.Any())
            {
                var male = maleStack.Peek();
                var female = femaleQueue.Peek();

                if (female <= 0)
                {
                    femaleQueue.Dequeue();
                    if (!femaleQueue.Any())
                    {
                        break;
                    }

                    continue;
                }
                if (male <= 0)
                {
                    maleStack.Pop();
                    if (!maleStack.Any())
                    {
                        break;
                    }
                    continue;
                }

                if (female % 25 == 0)
                {
                    femaleQueue.Dequeue();

                    if (!femaleQueue.Any())
                    {
                        break;
                    }
                    femaleQueue.Dequeue();
                    continue;
                }
                if (male % 25 == 0)
                {
                    maleStack.Pop();

                    if (!maleStack.Any())
                    {
                        break;
                    }
                    maleStack.Pop();
                    continue;
                }


                if (male == female)
                {
                    matchesCount++;
                    maleStack.Pop();
                    femaleQueue.Dequeue();
                }
                else
                {
                    femaleQueue.Dequeue();
                    male = maleStack.Pop();
                    male -= 2;
                    if (male <= 0)
                    {
                        continue;
                    }
                    maleStack.Push(male);
                }
            }

            Console.WriteLine("Matches: {0}", matchesCount);
            if (maleStack.Any())
            {
                Console.WriteLine("Males left: {0}", string.Join(", ", maleStack));
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (femaleQueue.Any())
            {
                Console.WriteLine("Females left: {0}", string.Join(", ", femaleQueue));
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
        public static int[] ReadInput(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
