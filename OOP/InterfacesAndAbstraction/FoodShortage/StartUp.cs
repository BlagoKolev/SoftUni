using System;
using System.Collections.Generic;
using FoodShortage.Intefaces;
using FoodShortage.Models;

namespace FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            var citizens = new List<Citizen>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    var birthdate = input[3];
                    buyers.Add(new Citizen(name, birthdate, id, age));
                }
                else if (input.Length == 3)
                {
                    var rebelName = input[0];
                    var rebelAge = int.Parse(input[1]);
                    var group = input[2];
                    buyers.Add(new Rebel(rebelName, rebelAge, group));
                }

            }
            var totalFood = 0;
            while (true)
            {
                var inputName = Console.ReadLine();
                if (inputName == "End")
                {
                    break;
                }

                foreach (var buyer in buyers)
                {
                    if (buyer.Name == inputName)
                    {
                        buyer.BuyFood();
                    }
                }
            }
            foreach (var buyer in buyers)
            {
                totalFood += buyer.Food;
            }
            Console.WriteLine(totalFood);




        }
    }
}
