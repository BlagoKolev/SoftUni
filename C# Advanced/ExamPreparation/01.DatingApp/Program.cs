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
            var males = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var females = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var femaleQueue = new Queue<int>(females);
            var maleStack = new Stack<int>(males);

            var matchesCount = 0;

            while (femaleQueue.Any() && maleStack.Any())
            {
                var female = femaleQueue.Peek();
                var male = maleStack.Peek();

                if (female <= 0)
                {
                    femaleQueue.Dequeue();
                    continue;
                }
                if (male <= 0)
                {
                    maleStack.Pop();
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
                if (female == male)
                {
                    matchesCount++;
                    femaleQueue.Dequeue();
                    maleStack.Pop();
                }
                else
                {
                    femaleQueue.Dequeue();
                    male = maleStack.Pop();
                    male -= 2;
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
    }
}
