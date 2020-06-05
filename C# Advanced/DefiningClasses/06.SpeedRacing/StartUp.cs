using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split();

                var model = carArgs[0];
                var fuelAmount = double.Parse(carArgs[1]);
                var fuelConsumptionPerKm = double.Parse(carArgs[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                var carModel = command[1];
                var amountOfKm = double.Parse(command[2]);

                var currentCar = cars.Where(x => x.Model == carModel).FirstOrDefault();

                currentCar.Move(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:f2} {2}", car.Model, car.FuelAmount, car.TravelledDistance);
            }
        }
    }
}
