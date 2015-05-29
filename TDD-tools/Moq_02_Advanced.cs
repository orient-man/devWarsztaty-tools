using System;
using System.Web;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace TDD_tools
{
    public class Moq_02_Advanced
    {
        [Test]
        public void mock_specifications()
        {
            // arrange
            var context = Mock.Of<HttpContextBase>(
                ctx =>
                    ctx.User.Identity.Name == "kzu" &&
                    ctx.Request.IsAuthenticated == true &&
                    ctx.Request.Url == new Uri("http://moqthis.com") &&
                    ctx.Response.ContentType == "application/xml");


            // act  assert
            Assert.That(context.User.Identity.Name, Is.EqualTo("kzu"));
            Assert.That(context.Request.IsAuthenticated, Is.True);
            // ...
        }

        [Test]
        public void loose_mocks_default()
        {
            var mock = new Mock<IFileWriter>(MockBehavior.Loose);
            Assert.DoesNotThrow(() => mock.Object.WriteLine("..."));
        }

        [Test]
        public void strict_mocks()
        {
            var mock = new Mock<IFileWriter>(MockBehavior.Strict);
            Assert.Throws<MockException>(() => mock.Object.WriteLine("..."));
        }

        [Test]
        public void recursive_mocks()
        {
            var mock = new Mock<HttpContextBase> { DefaultValue = DefaultValue.Mock };
            Assert.That(mock.Object.User.Identity, Is.Not.Null);
        }

        [Test]
        public void calling_base_mocks()
        {
            var mock = new Mock<Bar> { CallBase = true };
            mock.Setup(o => o.Method1()).Returns(-1);
            Assert.That(mock.Object.Method1(), Is.EqualTo(-1));
            Assert.That(mock.Object.Method2(), Is.EqualTo(2));
        }

        public class Bar
        {
            public virtual int Method1()
            {
                return 1;
            }

            public virtual int Method2()
            {
                return 2;
            }
        }

        [Test]
        public void protected_methods()
        {
            var mock = new Mock<Foo>();
            mock.Protected().Setup<int>("ProtectedMethod").Returns(5);
            Assert.That(mock.Object.PublicMethod(), Is.EqualTo(5));
        }

        public class Foo
        {
            public int PublicMethod()
            {
                return ProtectedMethod();
            }

            protected virtual int ProtectedMethod()
            {
                return -1;
            }
        }
    }
}