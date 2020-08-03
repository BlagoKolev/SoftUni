using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IRobot> robots;
        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public IList<IRobot> Robots => this.robots;

        public abstract void DoService(IRobot robot, int procedureTime);
        

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.Robots)
            {
                sb.AppendLine($"{robot}");
            }
            return sb.ToString().TrimEnd();
        }
        protected void CheckForEnoughProcedureTime(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }
    }
}
