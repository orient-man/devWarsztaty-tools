using System;
using NUnit.Framework;

namespace TDD_tools
{
    //    SetUpFixture.SetUp
    //    Constructor
    //    TestFixtureSetUp: Before any tests
    //    SetUp: Before each test
    //    Test A
    //    TearDown: After each test
    //    SetUp: Before each test
    //    Test B
    //    TearDown: After each test
    //    TestFixtureTearDown: After all test
    //    Disposing
    //    SetUpFixture.TearDown
    public class NUnit_XX_LifeCycle : IDisposable
    {
        public NUnit_XX_LifeCycle()
        {
            Console.WriteLine("Constructor");
        }

        [TestFixtureSetUp]
        public void BeforeAnyTests()
        {
            Console.WriteLine("TestFixtureSetUp: Before any tests");
        }

        [TestFixtureTearDown]
        public void AfterAllTests()
        {
            Console.WriteLine("TestFixtureTearDown: After all test");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing");
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Console.WriteLine("SetUp: Before each test");
        }

        [TearDown]
        public void AfterEachTest()
        {
            Console.WriteLine("TearDown: After each test");
        }

        [Test]
        public void TestA()
        {
            Console.WriteLine("Test A");
        }

        [Test]
        public void TestB()
        {
            Console.WriteLine("Test B");
        }
    }
}