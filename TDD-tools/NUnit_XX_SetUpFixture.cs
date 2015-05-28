using System;
using NUnit.Framework;

namespace TDD_tools
{
    [SetUpFixture]
    public class NUnit_XX_SetUpFixture
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            Console.WriteLine("SetUpFixture.SetUp");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            Console.WriteLine("SetUpFixture.TearDown");
        }
    }
}