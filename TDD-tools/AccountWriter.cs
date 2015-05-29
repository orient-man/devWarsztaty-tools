namespace TDD_tools
{
    public class AccountWriter
    {
        private readonly IFileWriter fileWriter;

        public AccountWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void Write(IAccountData account)
        {
            fileWriter.WriteLine(string.Format("Current balance: {0}", account.Balance));
            fileWriter.WriteLine(
                string.Format("History: {0}", string.Join(", ", account.History)));
        }
    }
}