using System.Collections;
using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_04_TestCaseSource
    {
        [TestCaseSource("TestCases")]
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

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200m, 150m, 100m);
                yield return new TestCaseData(300m, 50m, 70m);
                yield return new TestCaseData(200m, 150m, 300m)
                    .Throws(typeof(InsufficientFundsException))
                    .SetName("InsufficientFunds")
                    .SetDescription("An exception is expected");
            }
        }
    }
}