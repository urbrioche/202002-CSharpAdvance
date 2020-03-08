using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeyAnyTests
    {
        [Test]
        public void three_employees()
        {
            var emptyEmployees = new TSource[]
            {
                new TSource(),
                new TSource(),
                new TSource(),
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsTrue(actual);
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new TSource[]
            {
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsFalse(actual);
        }

        private bool JoeyAny(IEnumerable<TSource> employees)
        {
            throw new NotImplementedException();
        }
    }
}