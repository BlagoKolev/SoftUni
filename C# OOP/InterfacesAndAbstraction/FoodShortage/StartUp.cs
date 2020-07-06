using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rebels = new List<Rebel>();
            var citizens = new List<Citizen>();

            var n = int.Parse(Console.ReadLine());
           

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                if (input.Length ==4)
                {
                    var citizenName = input[0];
                    var citizenAge = int.Parse(input[1]);
                    var id = input[2];
                    var birthDate = input[3];
                    var citizen = new Citizen(citizenName, citizenAge, id, birthDate);
                    citizens.Add(citizen);
                }
                else
                {
                    var rebelName = input[0];
                    var rebelAge = int.Parse(input[1]);
                    var group = input[2];
                    var rebel = new Rebel(rebelName, rebelAge, group);
                    rebels.Add(rebel);
                }
               
            }
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (rebels.Any(x=>x.Name == name))
                {
                    var rebel = rebels.Where(x => x.Name==name).FirstOrDefault();
                    rebel.BuyFood();
                }
                else if (citizens.Any(x=>x.Name == name))
                {
                    var citizen = citizens.Where(x => x.Name == name).FirstOrDefault();
                    citizen.BuyFood();
                }
            }
            
            var rebelsFood = rebels.Sum(x => x.Food);
            var citizensFood = citizens.Sum(x => x.Food);
            var totalFood = rebelsFood + citizensFood;
            Console.WriteLine(totalFood);
        }
    }
}
