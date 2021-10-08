namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot1;
        private Robot robot2;
        private Robot robot3;
        private Robot robot4;
        private RobotManager manager;

        [SetUp]
        public void Setup()
        {
            robot1 = new Robot("robot1", 5);
            robot2 = new Robot("robot2", 6);
            robot3 = new Robot("robot3", 7);
            robot4 = new Robot("robot4", 8);
            manager = new RobotManager(3);
        }

        [Test]
        public void TestRobotIsCreated()
        {
            Assert.NotNull(robot1);
            Assert.AreEqual("robot1", robot1.Name);
            Assert.AreEqual(5, robot1.Battery);
            Assert.AreEqual(5, robot1.MaximumBattery);
        }
        
        [Test]
        public void ManagerIsCreated()
        {
            Assert.NotNull(manager);
            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(3, manager.Capacity);
        }
        
        [Test]
        public void NegativeCapacityThrowsException()
        {
            Assert.Throws<ArgumentException>(() => { RobotManager manager1 = new RobotManager(-7); });
        }
                

        [Test]
        public void TestAddThrowsExceptions()
        {
            manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => { manager.Add(robot1); });

            manager.Add(robot2);
            manager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() => { manager.Add(robot4); });
        }

        [Test]
        public void TestAddWorks()
        {
            manager.Add(robot1);
            manager.Add(robot2);

            Assert.AreEqual(2, manager.Count);

            manager.Add(robot3);

            Assert.AreEqual(3, manager.Count);
        }

        [Test]
        public void TestRemoveThrowsException()
        {
            manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("robot2"));
        }

        [Test]
        public void TestRemoveWorks()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            manager.Add(robot3);

            Assert.AreEqual(3, manager.Count);

            manager.Remove("robot2");

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void TesWorkThrowsExceptions()
        {
            manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => manager.Work("robot7", "Work", 2));
            Assert.Throws<InvalidOperationException>(() => manager.Work("robot1", "Work", 55));
        }

        [Test]
        public void TestWorkWorks()
        {            
            manager.Add(robot1);
            manager.Work("robot1", "Work", 2);

            Assert.AreEqual(3, robot1.Battery);
        }

        [Test]
        public void TestChargeThrowsExceptions()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("robot1"));
            Assert.Throws<InvalidOperationException>(() => manager.Charge("robot2"));
        }

        [Test]
        public void TestChargeWorks()
        {
            manager.Add(robot1);
            manager.Work("robot1", "Work", 2);
            manager.Charge("robot1");

            Assert.AreEqual(5, robot1.Battery);
        }
    }
}
