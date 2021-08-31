using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault vault;
        Item item1;
        Item item2;
        Item item3;

        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item1 = new Item("owner1", "Id1");
            this.item2 = new Item("owner2", "Id2");
            this.item3 = new Item("owner3", "Id3");
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(vault);
        }

        [Test]
        public void TestAddThrowsException()
        {
            this.vault.AddItem("A1", item2);

            Assert.Throws<ArgumentException>(() => vault.AddItem("A6", item1));
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item1));
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A3", item2));
        }

        [Test]
        public void TestAddWorks()
        {
            this.vault.AddItem("A1", item1);
            this.vault.AddItem("A2", item2);
            this.vault.AddItem("A3", item3);
            
            Assert.AreEqual(item1, this.vault.VaultCells["A1"]);
            Assert.AreEqual(item2, this.vault.VaultCells["A2"]);
            Assert.AreEqual(item3, this.vault.VaultCells["A3"]);
            Assert.IsNull(this.vault.VaultCells["A4"]);
        }

        [Test]
        public void TestRemoveThrowsException()
        {
            this.vault.AddItem("A1", item1);
            this.vault.AddItem("A2", item2);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A6", item1));
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item2));            
        }

        [Test]
        public void TestRemoveWorks()
        {
            this.vault.AddItem("A1", item1);
            this.vault.AddItem("A2", item2);

            Assert.AreEqual(item1, this.vault.VaultCells["A1"]);
            Assert.AreEqual(item2, this.vault.VaultCells["A2"]);

            this.vault.RemoveItem("A2", item2);

            Assert.AreEqual(item1, this.vault.VaultCells["A1"]);
            Assert.IsNull(this.vault.VaultCells["A2"]);
        }
    }
}