﻿using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            CheckForEnoughProcedureTime(robot, procedureTime);
            robot.Energy -= 8;
            robot.IsChecked = true;
            robot.ProcedureTime -= procedureTime;
        }
    }
}