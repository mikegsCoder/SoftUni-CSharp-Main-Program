using NUnit.Framework;
using System;

namespace Robots.Tests
{
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void Setup()
        {
            robot = new Robot("Test", 10);
            robotManager = new RobotManager(3);
        }

        [Test]
        public void WhenRobotIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("Test", robot.Name );
            Assert.AreEqual(10, robot.MaximumBattery);
            Assert.AreEqual(10, robot.Battery);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CapacityShouldBeSet()
        {
            Assert.AreEqual(3, robotManager.Capacity);
        }

        [Test]
        public void WhenRobotManagerIsCreatedWithNegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => { RobotManager manager = new RobotManager(-5); });
        }

        [Test]
        public void WhenRobotManagerIsCreated_CountShouldBeZero()
        {
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void WhenAddRobotMethodIsInvokedWithExistingRobot_ShouldThrowException()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => { robotManager.Add(robot); });
        }

        [Test]
        public void WhenAddCapacityIsExceed_ShouldThrowException()
        {
            Robot robot1 = new Robot("test", 20);
            Robot robot2 = new Robot("tEst", 30);
            Robot robot3 = new Robot("teSt", 40);

            robotManager.Add(robot);
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => { robotManager.Add(robot3); });
        }

        [Test]
        public void WhenAddMethodIsInvokedWithCorrectData_ShouldWorkProperly()
        {
            Robot robot1 = new Robot("test", 20);
            Robot robot2 = new Robot("tEst", 30);
            Robot robot3 = new Robot("teSt", 40);

            robotManager.Add(robot);
            robotManager.Add(robot1);

            Assert.AreEqual(2, robotManager.Count);

            robotManager.Add(robot2);

            Assert.AreEqual(3, robotManager.Count);
        }

        [Test]
        public void WhenRemoveNonExistingRobot_ShouldThrowException()
        {
            robotManager.Add(robot);
           
            Assert.Throws<InvalidOperationException>(() =>  robotManager.Remove("robot1"));
        }

        [Test]
        public void WhenRemoveMethodIsInvokedWithCorrectData_ShouldWorkProperly()
        {
            Robot robot1 = new Robot("test", 20);

            robotManager.Add(robot);
            robotManager.Add(robot1);

            Assert.AreEqual(2, robotManager.Count);

            robotManager.Remove("test");

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void WhenWorkIsInvokedWithWrongData_ShouldThrowException()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("robot1", "Job", 3));
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Test", "Job", 20));
        }

        [Test]
        public void WhenWorkIsInvokedWithCorrectData_ShouldWorkProperly()
        {
            Robot robot1 = new Robot("test", 20);

            robotManager.Add(robot);
            robotManager.Work("Test", "Job", 5);

            Assert.AreEqual(5, robot.Battery);
        }

        [Test]
        public void WhenChargeMethodIsInvokedWithWrongData_ShouldThrowException()
        {
            
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("robot1"));
        }

        [Test]
        public void WhenChargeMethodIsInvokedWithCorrectData_ShouldWorkProperly()
        {
            robotManager.Add(robot);
            robotManager.Work("Test", "Job", 5);
            robotManager.Charge("Test");

            Assert.AreEqual(10, robot.Battery);
        }
    }
}
