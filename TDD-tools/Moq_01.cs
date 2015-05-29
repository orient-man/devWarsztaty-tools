﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Moq;
using NUnit.Framework;

namespace TDD_tools
{
    public class Moq_01
    {
        private readonly Account account;

        public Moq_01()
        {
            account = new Account();
            account.Deposit(200);
            account.Withdraw(70);
            account.Deposit(50);
            account.Withdraw(10);
        }

        [Test]
        public void basic_verification()
        {
            // arrange
            var mockFileWriter = new Mock<IFileWriter>();
            var accountWriter = new AccountWriter(mockFileWriter.Object);

            // act
            accountWriter.Write(account);

            // assert
            mockFileWriter.Verify(fw => fw.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            mockFileWriter.Verify(
                fw => fw.WriteLine(It.Is<string>(s => s.StartsWith("Current balance: "))),
                Times.Once());
            mockFileWriter.Verify(
                fw => fw.WriteLine("History: 200, -70, 50, -10"),
                Times.Once());
        }

        [Test]
        public void setup_with_callbacks()
        {
            // arrange
            var mockFileWriter = new Mock<IFileWriter>();
            var sb = new StringBuilder();
            mockFileWriter
                .Setup(o => o.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => sb.AppendLine(s));
            var accountWriter = new AccountWriter(mockFileWriter.Object);

            // act
            accountWriter.Write(account);

            // assert
            Assert.That(sb.ToString(), Is.StringContaining("balance: 170"));
        }

        [Test]
        public void mock_all_the_things()
        {
            // arrange
            var mockAccount = new Mock<IAccountData>();
            mockAccount.SetupGet(o => o.Balance).Returns(170m);
            mockAccount
                .SetupGet(o => o.History)
                .Returns(new List<decimal> { 200, -70, 50, -10 });
            var mockFileWriter = new Mock<IFileWriter>();
            var accountWriter = new AccountWriter(mockFileWriter.Object);

            // act
            accountWriter.Write(account);

            // assert
            mockFileWriter.Verify(fw => fw.WriteLine("Current balance: 170"), Times.Once());
            mockFileWriter.Verify(fw => fw.WriteLine("History: 200, -70, 50, -10"), Times.Once());
        }

        [Test]
        public void classes_with_virtual_members()
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
    }
}