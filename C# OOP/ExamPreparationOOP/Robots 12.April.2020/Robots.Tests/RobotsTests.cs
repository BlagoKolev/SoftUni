namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    using System.Linq;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        private string name = "Robo";
        private int maxBatery = 100;
        private int capacity = 100;
        [Test]
        public void CheckRobotConstructorWorksProperly()
        {
            robot = new Robot(this.name, this.maxBatery);
            var expectedName = "Robo";
            var expectedMaxBattery = 100;
            var expectedBatery = 100;

            Assert.AreEqual(expectedName, robot.Name);
            Assert.AreEqual(expectedMaxBattery, robot.MaximumBattery);
            Assert.AreEqual(expectedBatery, robot.Battery);
        }

        [Test]
        public void CheckRobotManagerConstructorWorksProperly()
        {
            this.robotManager = new RobotManager(this.capacity);

            var expectedCapacity = 100;

            Assert.AreEqual(expectedCapacity, robotManager.Capacity);
        }
        [Test]
        public void CheckWheterCapacityThrowsExceptionIfValueIsNegativeNumber()
        {

            Assert.Throws<ArgumentException>(() =>
                {
                    robotManager = new RobotManager(-1);
                });
        }
        [Test]
        public void CheckWheterCountShowsCorrectNumber()
        {
            robotManager = new RobotManager(3);
            robot = new Robot(name, maxBatery);
            var robot2 = new Robot("Robo2", maxBatery);

            robotManager.Add(robot);
            robotManager.Add(robot2);

            var expectedCount = 2;
            Assert.AreEqual(expectedCount, robotManager.Count);
        }

        [Test]
        public void CheckWheterAddMethodThrowsExceptionIfThereIsAlreadySameRobotInCollection()
        {

            robotManager = new RobotManager(3);
            robot = new Robot(name, maxBatery);
            var robot2 = new Robot("Robo2", maxBatery);

            robotManager.Add(robot);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    robotManager.Add(robot2);

                });
        }
        [Test]
        public void CheckWheterAddMethodThrowsExceptionIfCapacityIsFull()
        {
            robotManager = new RobotManager(2);
            robot = new Robot(name, maxBatery);
            var robot2 = new Robot("Robo2", maxBatery);
            var robot3 = new Robot("Robo3", maxBatery);

            robotManager.Add(robot);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);

            });

        }
        [Test]
        public void CheckWheterRemoveThrowsExceptionIfNoSuchRobotInCollection()
        {
            robotManager = new RobotManager(2);
            robot = new Robot(name, maxBatery);
            var robot2 = new Robot("Robo2", maxBatery);
            var robot3 = new Robot("Robo3", maxBatery);

            robotManager.Add(robot);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    robotManager.Remove("Ansi");
                });
        }
        [Test]
        public void CheckWheterRemoveReduceTheCountOfCollection()
        {
            robotManager = new RobotManager(2);
            robot = new Robot(name, maxBatery);
            var robot2 = new Robot("Robo2", maxBatery);
            var robot3 = new Robot("Robo3", maxBatery);

            robotManager.Add(robot);
            robotManager.Add(robot2);
            robotManager.Remove("Robo2");

            var expectedCount = 1;
            Assert.AreEqual(expectedCount, robotManager.Count);
        }
        [Test]
        public void CheckWorkMethodReduceBatteryCorrect()
        {
            robot = new Robot(name, maxBatery);
            robotManager = new RobotManager(capacity);

            robotManager.Add(robot);

            robotManager.Work("Robo", "job", 10);

            var expectedBattry = 90;

            Assert.AreEqual(expectedBattry, robot.Battery);
        }
        [Test]
        public void CheckWorkThrowsExceptionIfRobotIsNull()
        {

            robot = new Robot(name, maxBatery);
            robotManager = new RobotManager(capacity);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Fifi", "job", 15);
            });
        }
        [Test]
        public void CheckWheterWorkThrowsExceptionIfRobotHasNotEnoughtBattery()
        {
            robot = new Robot(name, maxBatery);
            robotManager = new RobotManager(capacity);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robo", "job", 110);
            });
        }
        [Test]
        public void CheckWheterChargeThrowsExceptionIfRobotIsNull()
        {
            robot = new Robot(name, maxBatery);
            robotManager = new RobotManager(capacity);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("NaNi");
            });
        }
        [Test]
        public void CheckChargeWorksCorrect()
        {
            robot = new Robot(name, maxBatery);
            robotManager = new RobotManager(capacity);
            robotManager.Add(robot);

            robotManager.Work(name, "job", 60);

            robotManager.Charge(name);
            var expectedBattery = 100;

            Assert.AreEqual(expectedBattery, robot.Battery);
        }
    }
}
