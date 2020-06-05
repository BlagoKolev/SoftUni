using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split();

                var carModel = carArgs[0];
                var engineSpeed = int.Parse(carArgs[1]);
                var enginePower = int.Parse(carArgs[2]);
                var cargoWeight = int.Parse(carArgs[3]);
                var cargoType = carArgs[4];
                var tire1Pressure = double.Parse(carArgs[5]);
                var tire1Age = int.Parse(carArgs[6]);
                var tire2Pressure = double.Parse(carArgs[7]);
                var tire2Age = int.Parse(carArgs[8]);
                var tire3Pressure = double.Parse(carArgs[9]);
                var tire3Age = int.Parse(carArgs[10]);
                var tire4Pressure = double.Parse(carArgs[11]);
                var tire4Age = int.Parse(carArgs[10]);

                var car = new Car(carModel, engineSpeed, enginePower, cargoWeight
                    , cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age
                    , tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);
            }
            var wantedCargoType = Console.ReadLine();
            var resultList = new List<Car>();

            if (wantedCargoType == "fragile")
            {
                resultList = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else if (wantedCargoType == "flamable")
            {
                resultList = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, resultList));

        }
    }
}
