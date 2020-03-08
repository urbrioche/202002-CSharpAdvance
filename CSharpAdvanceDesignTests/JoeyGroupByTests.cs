using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeyGroupByTests
    {
        [Test]
        public void groupBy_lastName()
        {
            var employees = new List<TSource>
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "Tom", LastName = "Lee"},
                new TSource {FirstName = "Eric", LastName = "Chen"},
                new TSource {FirstName = "John", LastName = "Chen"},
                new TSource {FirstName = "David", LastName = "Lee"},
            };

            var actual = JoeyGroupBy(employees);
            Assert.AreEqual(2, actual.Count());
            var firstGroup = new List<TSource>
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "Eric", LastName = "Chen"},
                new TSource {FirstName = "John", LastName = "Chen"},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        private IEnumerable<IGrouping<string, TSource>> JoeyGroupBy(IEnumerable<TSource> employees)
        {
            throw new NotImplementedException();
        }
    }
}