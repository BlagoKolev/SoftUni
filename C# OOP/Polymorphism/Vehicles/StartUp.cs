using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carArgs = Console.ReadLine().Split();
            var carFuel = double.Parse(carArgs[1]);
            var carConsumption = double.Parse(carArgs[2]);
            Vehicle car = new Car(carFuel, carConsumption);

            var truckArgs = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckArgs[1]);
            var truckConsumption = double.Parse(truckArgs[2]);
            Vehicle truck = new Truck(truckFuel, truckConsumption);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "Drive")
                {
                    var distance = double.Parse(command[2]);
                    if (command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    var fuel = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
