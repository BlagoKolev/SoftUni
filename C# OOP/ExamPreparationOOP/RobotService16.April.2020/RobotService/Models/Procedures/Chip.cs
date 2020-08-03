using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            CheckForEnoughProcedureTime(robot, procedureTime);
            if (robot.IsChipped)
            {
                throw new ArgumentException(ExceptionMessages.AlreadyChipped);
            }
            robot.Happiness -= 5;
            robot.IsChipped = true;
            robot.ProcedureTime -= procedureTime;
        }
    }
}
