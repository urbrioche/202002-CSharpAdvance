using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyExceptTests
    {
        [Test]
        public void except_numbers()
        {
            var first = new[] { 1, 3, 5, 7, 3 };
            var second = new[] { 7, 1, 4, 1 };

            var actual = LinqExtensions.JoeyExcept(first, second);
            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void except_numbers_second_except_first()
        {
            var first = new[] { 1, 3, 5, 7, 3 };
            var second = new[] { 7, 1, 4, 1 };

            var actual = LinqExtensions.JoeyExcept(second, first);
            var expected = new[] { 4 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}