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
            var engineList = new HashSet<Engine>();
            var carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var engineArgs = Console.ReadLine().Split();

                Engine engine = null;

                var engineModel = engineArgs[0];
                var enginePower = int.Parse(engineArgs[1]);
                if (engineArgs.Length == 2)
                {
                    engine = new Engine(engineModel, enginePower);
                }

                else if (engineArgs.Length == 3)
                {
                    var powerValue = 0;
                    var isPossibleParse = int.TryParse(engineArgs[2], out powerValue);
                    if (isPossibleParse)
                    {
                        var displacement = powerValue;
                        engine = new Engine(engineModel, enginePower, displacement);
                    }
                    else
                    {
                        var efficiency = engineArgs[2];
                        engine = new Engine(engineModel, enginePower, efficiency);
                    }
                }

                else if (engineArgs.Length == 4)
                {
                    var displacement = int.Parse(engineArgs[2]);
                    var efficiency = engineArgs[3];
                    engine = new Engine(engineModel, enginePower, displacement, efficiency);
                }


                engineList.Add(engine);
            }


            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carArgs = Console.ReadLine().Split();

                Car car = null;

                var carModel = carArgs[0];
                var engineModel = carArgs[1];
                var currentEngine = engineList
                    .Where(x => x.Model == engineModel).FirstOrDefault();

                if (carArgs.Length == 2)
                {
                    car = new Car(carModel, currentEngine);
                }

                else if (carArgs.Length == 3)
                {

                    var weight = 0;
                    var isPossibleToParse = int.TryParse(carArgs[2], out weight);

                    if (isPossibleToParse)
                    {
                        car = new Car(carModel, currentEngine, weight);
                    }

                    else
                    {
                        var color = carArgs[2];
                        car = new Car(carModel, currentEngine, color);
                    }
                }

                else if (carArgs.Length == 4)
                {
                    var weight = int.Parse(carArgs[2]);
                    var color = carArgs[3];
                    car = new Car(carModel, currentEngine, weight, color);
                }

                carList.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }
    }
}
