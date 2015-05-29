using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace TDD_tools
{
    public class FluentAssertions_02
    {
        [Test]
        public void strings()
        {
            "ABCDEFGHI"
                .Should().StartWith("AB")
                .And.EndWith("HI")
                .And.Contain("EF")
                .And.HaveLength(9);
        }

        [Test]
        public void collections_1()
        {
            new[] { 1, 2, 3 }
                .Should().HaveCount(3)
                .And.Contain(x => x < 4)
                .And.BeInAscendingOrder()
                .And.OnlyHaveUniqueItems();
        }

        [Test]
        public void collections_2()
        {
            var quotations = CreateQuotations().ToList();
            quotations
                .Should()
                .HaveCount(2)
                .And.OnlyContain(q => q.Date == 31.July(2014))
                .And.ContainSingle(q => q.Ticker == "MSFT");
        }

        private static IEnumerable<Quotation> CreateQuotations()
        {
            var date = new DateTime(2014, 07, 31);
            yield return new Quotation { Ticker = "APPL", Close = 110.38m, Date = date };
            yield return new Quotation { Ticker = "MSFT", Close = 46.45m, Date = date };
        }

        [Test]
        public void dictionaries()
        {
            var dict = new Dictionary<int, Tuple<string, int>>
            {
                { 15, Tuple.Create("a", 5) },
                { 14, Tuple.Create("b", 4) }
            };
            dict
                .Should().NotContainKey(1)
                .And.ContainKey(15).WhichValue.Item2.Should().BeGreaterThan(0);
        }

        [Test]
        public void matching_types()
        {
            Exception ex = new ApplicationException("fix me");
            ex.Should()
                .BeAssignableTo<ApplicationException>()
                .Which.Message.Should().Be("fix me");
        }

        [Test]
        public void duck_matching()
        {
            var quotation =
                new Quotation { Ticker = "APPL", Close = 110.38m, Date = DateTime.Now };
            quotation
                .ShouldBeEquivalentTo(
                    new { Ticker = "APPL", Close = 110.38m },
                    options => options.ExcludingMissingMembers());
        }

        [Test]
        public void xml()
        {
            var doc = new XDocument(
                new XElement(
                    "configuration",
                    new XElement(
                        "setting",
                        new XAttribute("name", "foo"),
                        new XAttribute("value", "1"))));
            doc
                .Should()
                .HaveRoot("configuration")
                .And.HaveElement("setting")
                .Which.Should().BeOfType<XElement>()
                .And.HaveAttribute("name", "foo")
                .And.HaveAttribute("value", "1");
        }

        private class Quotation
        {
            public string Ticker { get; set; }
            public DateTime Date { get; set; }
            public decimal Close { get; set; }
        }
    }
}