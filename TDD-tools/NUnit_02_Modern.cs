using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_02_Modern
    {
        private Account source;
        private Account destination;

        [SetUp]
        public void Init()
        {
            source = new Account();
            source.Deposit(200m);

            destination = new Account();
            destination.Deposit(150m);
        }

        [Test]
        public void TransferFunds()
        {
            // act
            source.TransferFunds(destination, 100m);

            // assert
            Assert.That(destination.Balance, Is.EqualTo(250m));
            Assert.That(source.Balance, Is.EqualTo(100m));
        }

        [Test]
        public void TransferWithInsufficientFunds()
        {
            Assert.Throws<InsufficientFundsException>(
                () => source.TransferFunds(destination, 300m));
        }

        [Test]
        public void TransferWithInsufficientFundsAtomicity()
        {
            Assert.Throws<InsufficientFundsException>(
                () => source.TransferFunds(destination, 300m));

            Assert.That(destination.Balance, Is.EqualTo(150));
            Assert.That(source.Balance, Is.EqualTo(200));
        }
    }
}