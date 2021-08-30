namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        Fish fish1;
        Fish fish2;
        Fish fish3;

        [SetUp]
        public void Setup()
        {
            fish1 = new Fish("fish1");
            fish2 = new Fish("fish2");
            fish3 = new Fish("fish3");
        }

        [Test]
        public void TestNameThrowsException()
        {
            Aquarium current = null;

            Assert.Throws<ArgumentNullException>(() => current = new Aquarium(null, 20));
            Assert.Throws<ArgumentNullException>(() => current = new Aquarium("", 20));
        }

        [Test]
        public void TestCapacityThrowsException()
        {
            Aquarium current = null;

            Assert.Throws<ArgumentException>(() => current = new Aquarium("current", -1));
        }

        [Test]
        public void TestIsCreated()
        {
            Aquarium current = new Aquarium("current", 10);

            Assert.IsNotNull(current);
            Assert.AreEqual("current",current.Name);
            Assert.AreEqual(10,current.Capacity);
        }

        [Test]
        public void TestCount()
        {
            Aquarium current = new Aquarium("current", 10);
                        
            Assert.AreEqual(0, current.Count);
            current.Add(fish1);
            Assert.AreEqual(1, current.Count);
        }

        [Test]
        public void TestAddThrowsException()
        {
            Aquarium current = new Aquarium("current", 2);

            current.Add(fish1);
            current.Add(fish2);
            Assert.AreEqual(2, current.Count);
            Assert.Throws<InvalidOperationException>(() => current.Add(fish3));
        }

        [Test]
        public void TestRemoveThrowsException()
        {
            Aquarium current = new Aquarium("current", 2);

            current.Add(fish1);
            current.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => current.RemoveFish("fish3"));
        }

        [Test]
        public void TestRemoveWorks()
        {
            Aquarium current = new Aquarium("current", 5);

            current.Add(fish1);
            current.Add(fish2);
            Assert.AreEqual(2, current.Count);

            current.RemoveFish("fish2");
            Assert.AreEqual(1, current.Count);
        }

        [Test]
        public void TestSellFishThrowsException()
        {
            Aquarium current = new Aquarium("current", 5);

            current.Add(fish1);
            current.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => current.SellFish("fish3"));
        }

        [Test]
        public void TestSellFishWorks()
        {
            Aquarium current = new Aquarium("current", 5);

            current.Add(fish1);
            current.Add(fish2);
            Assert.AreEqual(2, current.Count);

            var sold =  current.SellFish("fish2");

            Assert.AreEqual(fish2, sold);
            Assert.IsFalse(sold.Available);
        }

        [Test]
        public void TestReport()
        {
            Aquarium current = new Aquarium("current", 5);

            current.Add(fish1);
            current.Add(fish2);
            Assert.AreEqual(2, current.Count);

            string result = "Fish available at current: fish1, fish2";

            Assert.AreEqual(result, current.Report());
        }
    }
}
