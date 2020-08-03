﻿using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures;


namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Chip chip;
        private Polish polish;
        private TechCheck techCheck;
        private Rest rest;
        private Work work;
        private Charge charge;
        public Controller()
        {
            this.garage = new Garage();
            this.chip = new Chip();
            this.polish = new Polish();
            this.techCheck = new TechCheck();
            this.rest = new Rest();
            this.work = new Work();
            this.charge = new Charge();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            switch (robotType)
            {
                case "PetRobot": robot = new PetRobot(name, energy, happiness, procedureTime); break;
                case "HouseholdRobot": robot = new HouseholdRobot(name, energy, happiness, procedureTime); break;
                case "WalkerRobot": robot = new WalkerRobot(name, energy, happiness, procedureTime); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType,robotType));
            }
            this.garage.Manufacture(robot);
            return $"Robot {name} registered successfully";
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.charge.DoService(curretnRobot, procedureTime);
            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.chip.DoService(curretnRobot, procedureTime);
            this.chip.Robots.Add(curretnRobot);
            return string.Format(OutputMessages.ChipProcedure, robotName);
          
        }
           
              
        public string Polish(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.polish.DoService(curretnRobot, procedureTime);
            this.polish.Robots.Add(curretnRobot);
            return string.Format(OutputMessages.PolishProcedure , robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.rest.DoService(curretnRobot, procedureTime);
            this.rest.Robots.Add(curretnRobot);
            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            var outputMsg = curretnRobot.IsChipped ? $"{ownerName} bought robot with chip" : $"{ownerName} bought robot without chip";
            return outputMsg;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.techCheck.DoService(curretnRobot, procedureTime);
            this.techCheck.Robots.Add(curretnRobot);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);

        }

        public string Work(string robotName, int procedureTime)
        {
            CheckIfRobotExistInGarage(robotName, this.garage);
            var curretnRobot = this.garage.Robots[robotName];
            this.work.DoService(curretnRobot, procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName,procedureTime);
        }

        public string History(string procedureType)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{procedureType}");

            switch (procedureType)
            {
                case "Charge":
                    foreach (var robot in this.charge.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;

                case "Chip":
                    foreach (var robot in this.chip.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;

                case "Polish":
                    foreach (var robot in this.polish.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;

                case "Rest":
                    foreach (var robot in this.rest.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;

                case "TechCheck":
                    foreach (var robot in this.techCheck.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;

                case "Work":
                    foreach (var robot in this.work.Robots)
                    {
                        sb.AppendLine($"{robot}");
                    };
                    break;
            }
            return sb.ToString().TrimEnd();
        }

        private void CheckIfRobotExistInGarage(string robotName, IGarage garage)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
