using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new SportCar(100, 100);
            car.Drive(10);
            Console.WriteLine(car.Fuel);

        }
    }
}
