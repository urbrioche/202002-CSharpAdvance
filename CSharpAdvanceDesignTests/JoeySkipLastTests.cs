using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySkipLastTests
    {
        [Test]
        public void skip_last_2()
        {
            var numbers = new[] { 10, 20, 30, 40, 50 };
            var actual = LinqExtensions.JoeySkipLast(numbers, 2);

            var expected = new[] { 10, 20, 30 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        [Test]
        public void skip_last_2_with_2_numbers()
        {
            var numbers = new[] { 40, 50 };
            var actual = LinqExtensions.JoeySkipLast(numbers, 2);

            var expected = new int[] { };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void skip_last_2_with_1_numbers()
        {
            var numbers = new[] { 40 };
            var actual = LinqExtensions.JoeySkipLast(numbers, 2);

            var expected = new int[] { };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void skip_last_0()
        {
            var numbers = new[] { 10, 20, 30, 40, 50 };
            var actual = LinqExtensions.JoeySkipLast(numbers, 0);

            var expected = new[] { 10, 20, 30, 40, 50 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}