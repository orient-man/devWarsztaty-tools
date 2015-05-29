using System.Collections.Generic;

namespace TDD_tools
{
    public interface IAccountData
    {
        decimal Balance { get; }
        List<decimal> History { get; }
    }
}