using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using ExpectedObjects;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyAverageTests
    {
        [Test]
        public void average_with_null_value()
        {
            var numbers = new int?[] {2, 4, null, 6};

            var actual = JoeyAverage(numbers);

            4.ToExpectedObject().ShouldMatch(actual);
        }

        private double? JoeyAverage(IEnumerable<int?> numbers)
        {
            throw new System.NotImplementedException();
        }
    }
}