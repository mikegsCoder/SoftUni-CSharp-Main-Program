using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        UnitCar car1;
        UnitCar car2;
        UnitCar car3;
        UnitDriver driver1;
        UnitDriver driver2;
        UnitDriver driver3;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.car1 = new UnitCar("model1", 100, 1200);
            this.car2 = new UnitCar("model2", 120, 1300);
            this.car3 = new UnitCar("model3", 140, 1500);
            this.driver1 = new UnitDriver("driver1", car1);
            this.driver2 = new UnitDriver("driver2", car2);
            this.driver3 = new UnitDriver("driver3", car3);
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void TestAddDriverTrowsExceptions()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

            this.raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver1));
        }

        [Test]
        public void TestAddDriverWorksProperly()
        {     
            this.raceEntry.AddDriver(driver1);
            Assert.AreEqual(1, raceEntry.Counter);

            StringAssert.AreEqualIgnoringCase("Driver driver2 added in race.", this.raceEntry.AddDriver(driver2));
        }

        [Test]
        public void TestCalculateAverageHorsePowerTrowsExceptions()
        {          
            this.raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateAverageHorsePowerWorksProperly()
        {
            this.raceEntry.AddDriver(driver1);
            this.raceEntry.AddDriver(driver2);
            this.raceEntry.AddDriver(driver3);
            Assert.AreEqual(120 ,raceEntry.CalculateAverageHorsePower());
        }
    }
}