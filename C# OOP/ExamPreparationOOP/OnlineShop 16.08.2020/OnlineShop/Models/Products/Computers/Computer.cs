using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
            }

        }

        public override decimal Price
        {
            get
            {
                var componentsPrice = this.Components.Sum(x => x.Price);
                var peripheralPrice = this.Peripherals.Sum(x => x.Price);
                return base.Price + componentsPrice + peripheralPrice;
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any() || !this.Components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            IComponent component = this.Components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any() || !this.Peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            IPeripheral peripheral = this.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");

            if (this.Components.Count == 0)
            {
                sb.AppendLine($" Components (0):");
            }
            else
            {
                sb.AppendLine($" Components ({this.Components.Count}):");
                foreach (var component in this.components)
                {
                    sb.AppendLine($"  {component.ToString()}");
                }
            }
            double average = 0.00;
            if (this.Peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({0}); Average Overall Performance ({average:f2}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(x => x.OverallPerformance):f2}):");

                foreach (var peripheral in this.Peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }
            }
           

            return sb.ToString().TrimEnd();
        }
    }
}
