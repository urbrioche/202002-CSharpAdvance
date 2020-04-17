using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyAverageTests
    {
        [Test]
        public void average_with_null_value()
        {
            var numbers = new int?[] { 2, 4, null, 6 };

            var actual = numbers.JoeyAverage();

            4d.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void average_result_with_decimal_places_source_with_null_value()
        {
            var numbers = new int?[] { 1, 1, null, 4, 4 };

            var actual = numbers.JoeyAverage();

            2.5d.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void average_all_null_value()
        {
            var numbers = new int?[] { null, null, null };

            var actual = numbers.JoeyAverage();

            Assert.IsNull(actual);
        }
    }
}