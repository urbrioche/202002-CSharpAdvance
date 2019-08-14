using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = employees.JoeyFirstOrDefault();

            Assert.IsNull(actual);
        }

        [Test]
        public void nullable_of_int_first_or_default()
        {
            var numbers = new List<int?>();

            var actual = numbers.JoeyFirstOrDefault();

            Assert.IsNull(actual);
        }

        [Test]
        public void empty_numbers_with_int()
        {
            var numbers = new List<int>() { };

            var actual = numbers.JoeyFirstOrDefault();

            Assert.AreEqual(0, actual);
        }
    }
}