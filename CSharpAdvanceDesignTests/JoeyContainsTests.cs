using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeyContainsTests
    {
        [Test]
        public void contains_joey_chen()
        {
            var employees = new List<TSource>
            {
                new TSource(){FirstName = "Joey", LastName = "Wang"},
                new TSource(){FirstName = "Tom", LastName = "Li"},
                new TSource(){FirstName = "Joey", LastName = "Chen"},
            };

            var joey = new TSource() { FirstName = "Joey", LastName = "Chen" };

            var actual = JoeyContains(employees, joey);

            Assert.IsTrue(actual);
        }

        private bool JoeyContains(IEnumerable<TSource> employees, TSource value)
        {
            throw new System.NotImplementedException();
        }
    }
}