using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<string, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>()
            {
                { "Charge", new Charge() },
                { "Chip", new Chip() },
                { "Polish", new Polish() },
                { "Rest", new Rest() },
                { "TechCheck", new TechCheck() },
                { "Work", new Work() }
            };
        }

        public string Charge(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["Charge"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);
                        
            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["Chip"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var procedure = this.procedures[procedureType];

            return procedure.History().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }

            if (robot == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["Polish"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["Rest"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            var outputMsg = robot.IsChipped
                ? $"{ownerName} bought robot with chip"
                : $"{ownerName} bought robot without chip";

            return outputMsg;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["TechCheck"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            this.CheckRobot(robotName);

            var robot = this.garage.Robots[robotName];
            var procedure = this.procedures["Work"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private void CheckRobot(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
