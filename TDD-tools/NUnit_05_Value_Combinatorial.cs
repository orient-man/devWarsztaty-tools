using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_05_Value_Combinatorial
    {
        [Test, Combinatorial]
        public void TransferFunds(
            [Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            // ...
        }
    }
}