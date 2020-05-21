using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var petrolPumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(input);
            }

            var tankPetrol = 0;
            var turn = 0;
            while (true)
            {
                var isNegative = false;
                for (int i = 0; i < n; i++)
                {

                    var currentPump = petrolPumps.Dequeue();
                    var petrol = currentPump[0];
                    var km = currentPump[1];
                    tankPetrol += petrol;

                    if (tankPetrol < km)
                    {
                        isNegative = true;
                    }
                    tankPetrol -= km;
                    petrolPumps.Enqueue(currentPump);
                }

                if (isNegative)
                {
                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                    turn++;
                    tankPetrol = 0;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(turn);
        }
    }
}
