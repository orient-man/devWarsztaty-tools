using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_06_Misc
    {
        [Test, Category("Integration")]
        public void Integration_Test()
        {
        }

        [Test, IntegrationTest]
        public void Another_Integration_Test()
        {
        }
    }

    public class IntegrationTestAttribute : CategoryAttribute
    {
        public IntegrationTestAttribute() : base("Integration")
        {
        }
    }
}