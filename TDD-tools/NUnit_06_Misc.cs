using NUnit.Framework;

namespace TDD_tools
{
    public class IntegrationTestAttribute : CategoryAttribute
    {
        public IntegrationTestAttribute() : base("Integration")
        {
        }
    }
}