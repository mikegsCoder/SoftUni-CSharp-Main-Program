using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfNullOrDuplicateDadaIsProvided()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));

            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);
            computerManager.AddComputer(computer);

            Assert.AreEqual(computerManager.Count, 1);
            Assert.AreEqual(computerManager.Computers.Count, 1);
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenInvalidDataIsProvided()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("test", null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "test"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("test", "test"));                       
        }

        [Test]
        public void GetComputerShouldWorkProperly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);
            computerManager.AddComputer(computer);

            Computer computerFromComputerManager = computerManager.GetComputer("manufacturer", "model");
                       
            Assert.AreEqual(computer, computerFromComputerManager);
        }

        [Test]
        public void RemoveComputerShouldWorkProperly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);
            computerManager.AddComputer(computer);

            Computer computerFromComputerManager = computerManager.RemoveComputer("manufacturer", "model");

            Assert.AreEqual(computer, computerFromComputerManager);
            Assert.AreEqual(computerManager.Computers.Count, 0);
            Assert.AreEqual(computerManager.Count, 0);
        }

        [Test]
        public void RemoveComputerShouldThrowException()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "model"));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("manufacturer", null));
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("nonExisting", "nonExisting"));
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkProperly()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("manufacturer", "model", 10);
            Computer computer1 = new Computer("manufacturer", "model23", 30);
            Computer computer2 = new Computer("manufacturer", "model45", 40);
            Computer computer3 = new Computer("manufacturer23", "model54", 50);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            ICollection<Computer> computersFromComputerManager = computerManager.GetComputersByManufacturer("manufacturer");

            CollectionAssert.Contains(computersFromComputerManager, computer);
            CollectionAssert.Contains(computersFromComputerManager, computer1);
            CollectionAssert.Contains(computersFromComputerManager, computer2);
            CollectionAssert.DoesNotContain(computersFromComputerManager, computer3);

            Assert.AreEqual(computersFromComputerManager.Count, 3);           
        }
    }
}