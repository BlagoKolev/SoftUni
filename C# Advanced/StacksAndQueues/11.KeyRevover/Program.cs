using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = ReadInput();
            var locks = ReadInput();
            var intelligenceValue = int.Parse(Console.ReadLine());
            var bulletsStack = new Stack<int>(bullets);
            var locksQueue = new Queue<int>(locks);
            var bulletsCounter = 0;
            var moneyForBullets = 0;
            while (bulletsStack.Count > 0 && locksQueue.Count > 0)
            {
                var currentBullet = bulletsStack.Pop();
                bulletsCounter++;
                moneyForBullets += bulletPrice;
                var currentLock = locksQueue.Peek();
                if (currentBullet <= currentLock)
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsCounter == gunBarrelSize)
                {
                    bulletsCounter = 0;
                    if (bulletsStack.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                }

            }

            if (locksQueue.Count == 0)
            {
                var difference = intelligenceValue - moneyForBullets;
                Console.WriteLine("{0} bullets left. Earned ${1}", bulletsStack.Count, difference);
            }
            else if (bulletsStack.Count == 0)
            {
                Console.WriteLine("Couldn't get through. Locks left: {0}", locksQueue.Count);
            }

        }
        public static int[] ReadInput()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return numbers;
        }
    }
}
