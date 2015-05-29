using System;
using FluentAssertions;
using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_03_FluentAssertions

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
            destination.Balance.Should().Be(250m);
            source.History.Should().BeEquivalentTo(new[] { 200, -100m });
            source.Balance.Should().Be(100m);
            source.History.Should().BeEquivalentTo(new[] { 200, -100m });
            destination.History.Should().BeEquivalentTo(new[] { 150, 100m });
        }

        [Test]
        public void TransferWithInsufficientFunds()
        {
            Action act = () => source.TransferFunds(destination, 300m);
            act.ShouldThrow<InsufficientFundsException>();
        }
    }
}