using NUnit.Framework;

namespace TDD_tools
{
    public class NUnit_07_Misc
    {
        [Test, Category("Integration")]
        public void Integration_Test()
        {
            System.Threading.Thread.Sleep(1000);
        }

        [Test, IntegrationTest]
        public void Another_Integration_Test()
        {
        }
    }
}