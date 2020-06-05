using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity = 0;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }
        public List<Car> Cars
        {
            get { return this.cars; }
            private set { this.cars = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        private int count;

        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }


        public string AddCar(Car car)
        {
            var regNum = car.RegistrationNumber;
            if (this.cars.Any(x => x.RegistrationNumber == regNum))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == this.Capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            this.Count++;
            return string.Concat("Successfully added new car " + car.Make + ' ' + car.RegistrationNumber);

        }

        public string RemoveCar(string regNumber)
        {
            var isCarExist = false;
            Car currentCar = null;

            foreach (var car in this.Cars)
            {

                if (car.RegistrationNumber == regNumber)
                {
                    isCarExist = true;
                    currentCar = car;
                    break;
                }
            }
            if (isCarExist)
            {

                this.Cars.Remove(currentCar);
                this.Count--;
                return string.Concat("Successfully removed " + regNumber);
            }
            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string regNumber)
        {
            Car currentCar = null;
            foreach (var car in this.Cars)
            {
                if (car.RegistrationNumber == regNumber)
                {
                    currentCar = car;
                }
            }
            return currentCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                var currentRegNumber = RegistrationNumbers[i];

                foreach (var car in this.Cars)
                {
                    if (car.RegistrationNumber == currentRegNumber)
                    {
                        car.RegistrationNumber = null;
                        break;
                    }
                }
                if (this.Cars.Any(x => x.RegistrationNumber == null))
                {
                    this.Cars.RemoveAll(x => x.RegistrationNumber == null);
                    this.Count--;
                }
            }
        }
    }
}
