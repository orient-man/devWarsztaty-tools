namespace TDD_tools
{
    public class Account
    {
        public decimal Balance { get; private set; }

        public decimal MinimumBalance { get { return 10m; } }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
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