using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var daturaBombs = 40;
            var cherryBombs = 60;
            var smokeDecoyBombs = 120;
            var daturaCounter = 0;
            var cherryCounter = 0;
            var smokeDecoyCounter = 0;
            var filledBombPouch = false;

            var effectsQueue = new Queue<int>(bombEffects);
            var casingStack = new Stack<int>(bombCasing);

            while (effectsQueue.Any() && casingStack.Any())
            {
                var effect = effectsQueue.Peek();
                var casing = casingStack.Peek();

                if (effect + casing == daturaBombs)
                {
                    daturaCounter++;
                    effectsQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (effect + casing == cherryBombs)
                {
                    cherryCounter++;
                    effectsQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (effect + casing == smokeDecoyBombs)
                {
                    smokeDecoyCounter++;
                    effectsQueue.Dequeue();
                    casingStack.Pop();
                }
                else
                {
                    casingStack.Pop();
                    casing -= 5;
                    casingStack.Push(casing);
                }
                if (daturaCounter >= 3 && cherryCounter >= 3 && smokeDecoyCounter >= 3)
                {
                    filledBombPouch = true;
                    break;
                }
            }

            if (filledBombPouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effectsQueue.Any())
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effectsQueue));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casingStack.Any())
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casingStack));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {cherryCounter}");
            Console.WriteLine($"Datura Bombs: {daturaCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyCounter}");
        }
    }
}
