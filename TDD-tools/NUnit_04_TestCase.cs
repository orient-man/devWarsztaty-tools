using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_04_TestCase
    {
        [TestCase(200, 150, 100)]
        [TestCase(300, 50, 70)]
        [TestCase(200, 150, 300, ExpectedException = typeof(InsufficientFundsException))]
        public void TransferFunds(decimal srcBalance, decimal destBalance, decimal transfer)
        {
            // arrange
            var source = new Account();
            source.Deposit(srcBalance);

            var destination = new Account();
            destination.Deposit(destBalance);

            // act
            source.TransferFunds(destination, transfer);

            // assert
            Assert.That(destination.Balance, Is.EqualTo(destBalance + transfer));
            Assert.That(source.Balance, Is.EqualTo(srcBalance - transfer));
        }
    }
}