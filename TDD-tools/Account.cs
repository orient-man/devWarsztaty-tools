using System.Collections.Generic;

namespace TDD_tools
{
    public class Account : IAccountData
    {
        private readonly List<decimal> history = new List<decimal>();

        public decimal Balance { get; private set; }

        public decimal MinimumBalance { get { return 10m; } }

        public List<decimal> History { get { return history; } }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            history.Add(amount);
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            history.Add(-amount);
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            if (Balance - amount < MinimumBalance)
                throw new InsufficientFundsException();

            destination.Deposit(amount);
            Withdraw(amount);
        }
    }
}