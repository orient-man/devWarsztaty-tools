using NCrunch.Framework;
using NUnit.Framework;

namespace TDD_tools
{
    [Category("Integration")]
    public class NCrunch_Misc
    {
        [Test, RequiresCapability("Microsoft Word")]
        public void word_automation_test()
        {
        }

        [Test, RequiresCapability("Access 32bit Driver")]
        public void ms_access_database_reading_test()
        {
        }

        [Test, RequiresCapability("Oracle Test Db")]
        public void oracle_database_test()
        {
        }
    }
}