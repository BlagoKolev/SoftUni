using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using RobotService.Utilities.Messages;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CAPACITY = 10;
        private Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots.ToImmutableDictionary();

        public int Capacity
        {
            get { return CAPACITY; }
        }
        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.Any(x => x.Key == robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            this.robots[robot.Name] = robot;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var robot = this.Robots[robotName];
            robot.IsBought = true;
            robot.Owner = ownerName;
            this.robots.Remove(robotName);
        }
    }
}
