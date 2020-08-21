using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using OnlineShop.Models.Products.Components;
using System.Linq;
using System.Text;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            switch (computerType)
            {
                case "DesktopComputer": computer = new DesktopComputer(id, manufacturer, model, price); break;
                case "Laptop": computer = new Laptop(id, manufacturer, model, price); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExist(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit": component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation); break;
                case "Motherboard": component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation); break;
                case "PowerSupply": component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation); break;
                case "RandomAccessMemory": component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation); break;
                case "SolidStateDrive": component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation); break;
                case "VideoCard": component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExist(computerId);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            var componentToRemove = computer.RemoveComponent(componentType);
            this.components.Remove(componentToRemove);
            return string.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExist(computerId);

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "Headset": peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Keyboard": peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Monitor": peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Mouse": peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType));
            }

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, computer.Id);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExist(computerId);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            IPeripheral peripheralToRemove = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExist(id);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            this.computers.Remove(computer);

            return $"{computer}";
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any() || !this.computers.Any(x => x.Price <= budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer computer = this.computers.OrderByDescending(x => x.OverallPerformance).Where(x => x.Price <= budget).FirstOrDefault();

            this.computers.Remove(computer);

            return $"{computer}";
        }


        public string GetComputerData(int id)
        {
            CheckIfComputerExist(id);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            return $"{computer}";
        }



        private void CheckIfComputerExist(int id)
        {
            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
