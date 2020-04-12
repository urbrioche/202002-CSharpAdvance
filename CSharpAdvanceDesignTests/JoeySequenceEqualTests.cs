using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySequenceEqualTests
    {
        [Test]
        public void compare_two_numbers_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_diff()
        {
            var first = new List<int> { 3, 2, 2 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void first_longer()
        {
            var first = new List<int> { 3, 2, 1, 0 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void second_longer()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1, 0 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void two_empty_list()
        {
            var first = new List<int>();
            var second = new List<int>();

            var actual = first.JoeySequenceEqual(second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void two_list_first_empty()
        {
            var first = new List<int>();
            var second = new List<int> { 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }
    }
}