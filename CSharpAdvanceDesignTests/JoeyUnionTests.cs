using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyUnionTests
    {
        [Test]
        public void union_numbers()
        {
            var first = new[] {1, 3, 5, 1};
            var second = new[] {5, 3, 7};

            var actual = first.JoeyUnion(second);
            var expected = new[] {1, 3, 5, 7};

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}