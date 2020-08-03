using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            CheckForEnoughProcedureTime(robot, procedureTime);
            robot.Happiness -= 7;
            robot.ProcedureTime -= procedureTime;
        }
    }
}
