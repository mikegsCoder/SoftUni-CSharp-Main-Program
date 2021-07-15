using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        public ITransaction Transaction { get; set; }
        public IChainblock Chainblock { get; set; }

        [SetUp]
        public void SetUp()
        {
            // Arrange
            this.Transaction = new Transaction()
            {
                Id = 1,
                From = "Filip",
                To = "Victor",
                Status = TransactionStatus.Successfull,
                Amount = 1
            };

            this.Chainblock = new Chainblock.Models.Chainblock();
        }

        // Given_When_Then = naming convention
        [Test]
        [Category("[Add method]")]
        public void Given_Transaction_When_AddTransactionIsCalled_Then_TransactionsCountIncreases()
        {
            // Arrange            
            int expectedChainblockCount = 1;

            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.AreEqual(expectedChainblockCount, this.Chainblock.Count);
        }

        [Test]
        [Category("[Add method]")]
        public void Given_DuplicateTransaction_When_AddTransactionIsCalled_Then_ThrowInvalidOperationException()
        {
            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.Add(this.Transaction));
        }

        [Test]
        [Category("[Count property]")]
        public void Given_PropertyCountValue_When_CountGetterIsCalled_Then_ProperNumberIsReturned()
        {
            // Arrange
            int expectedChainblockCount = 0;

            // Assert
            Assert.AreEqual(expectedChainblockCount, this.Chainblock.Count);
        }

        [Test]
        [Category("[Contains] --> id method")]
        public void Given_ExistingId_When_ContainsByIsCalled_Then_ReturnsTrue()
        {
            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.IsTrue(this.Chainblock.Contains(this.Transaction.Id));
        }

        [Test]
        [Category("[Contains] --> id method")]
        public void Given_NonExistingId_When_ContainsByIsCalled_Then_ReturnsFale()
        {
            // Assert
            Assert.IsFalse(this.Chainblock.Contains(this.Transaction.Id));
        }

        [Test]
        [Category("[Contains] --> id method")]
        [TestCase(-1)]
        [TestCase(0)]
        public void Given_ZeroOrNegativeId_When_ContainsByIsCalled_Then_ThrowsArgumentException(int invalidId)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => this.Chainblock.Contains(invalidId));
        }

        [Test]
        [Category("[Contains] --> transaction method")]
        public void Given_ExistingTransaction_When_ContainsByTransactionCalled_Then_ReturnsTrue()
        {
            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.IsTrue(this.Chainblock.Contains(this.Transaction));
        }

        [Test]
        [Category("[Contains] --> transaction method")]
        public void Given_NonExistingTransaction_When_ContainsByTransactionCalled_Then_ReturnsFalse()
        {
            // Assert
            Assert.IsFalse(this.Chainblock.Contains(this.Transaction));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndValidStatus_When_ChangeTransactionStatusIsCalled_Then_StatusIsChanged()
        {
            // Act
            this.Chainblock.Add(this.Transaction);
            var newTransactionStatus = TransactionStatus.Aborted;
            this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, newTransactionStatus);

            // Assert
            Assert.AreEqual(newTransactionStatus, this.Transaction.Status);
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndSameStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowsInvalidOperationException()
        {
            // Act
            this.Chainblock.Add(this.Transaction);
            var newTransactionStatus = TransactionStatus.Successfull;

            // Assert
            Assert.Throws<InvalidOperationException>
                (() => this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, newTransactionStatus));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_NotExistingIdAndStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowsArgumentException()
        {
            // Arrange
            int notExistingId = 3;

            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.Throws<ArgumentException>
                (() => this.Chainblock.ChangeTransactionStatus(notExistingId, TransactionStatus.Failed));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        public void Given_ValidIdAndNonExidtingStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowsInvalidOperationException()
        {
            // Arrange
            int nvalidTransactionStatusValue = 15;

            // Act
            this.Chainblock.Add(this.Transaction);

            // Assert
            Assert.Throws<InvalidOperationException>
                (() => this.Chainblock.ChangeTransactionStatus(this.Transaction.Id, (TransactionStatus)nvalidTransactionStatusValue));
        }

        [Test]
        [Category("[ChangeTransactionStatus] method")]
        [TestCase(-1)]
        [TestCase(0)]
        public void Given_ZeroOrNegativeIdAndExidtingStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowsArgumentException(int invalidId)
        {
            // Arrange
            string expectedMessage = "Id can not be less or equal to zero.";

            // Assert
            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => this.Chainblock.ChangeTransactionStatus(invalidId, TransactionStatus.Unauthorized));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }
}
