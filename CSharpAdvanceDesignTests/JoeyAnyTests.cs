using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAnyTests
    {
        [Test]
        public void three_employees()
        {
            var emptyEmployees = new Employee[]
            {
                new Employee(),
                new Employee(),
                new Employee(),
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsTrue(actual);
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsFalse(actual);
        }

        [Test]
        public void any_number_greater_than_91()
        {
            var numbers = new[] {87, 88, 91, 93, 0};
            var actual = JoeyAnyWithCondition(numbers);
            Assert.IsTrue(actual);
        }

        private bool JoeyAnyWithCondition(IEnumerable<int> source)
        {
            throw new NotImplementedException();
        }

        private bool JoeyAny<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext();
        }
    }
}