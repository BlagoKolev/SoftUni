using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Car car)
        {
            if (this.Count <this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var isCarExist = false;
            var carToRemove = this.data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            if (carToRemove!=null)
            {
                this.data.Remove(carToRemove);
                isCarExist = true;
            }
            return isCarExist;
        }

        public Car GetLatestCar()
        {
            var latestCar = this.data.OrderByDescending(x => x.Year).FirstOrDefault();
            return latestCar;
        }
        public Car GetCar(string manufacturer, string model)
        {
            var currentCar = this.data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            return currentCar;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:")
                .AppendLine(string.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }
    }
}
