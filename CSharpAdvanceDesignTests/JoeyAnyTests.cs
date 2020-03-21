using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Lab;

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

            var actual = emptyEmployees.JoeyAny();
            Assert.IsTrue(actual);
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = emptyEmployees.JoeyAny();
            Assert.IsFalse(actual);
        }

        [Test]
        public void any_number_greater_than_91()
        {
            var numbers = new[] { 87, 88, 91, 93, 0 };
            var actual = JoeyAnyWithCondition(numbers, current => current > 91);
            Assert.IsTrue(actual);
        }

        private bool JoeyAnyWithCondition(IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            var enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }
    }
}