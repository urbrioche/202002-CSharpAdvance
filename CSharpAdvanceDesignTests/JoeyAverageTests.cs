using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyAverageTests
    {
        [Test]
        public void average_with_null_value()
        {
            var numbers = new int?[] { 2, 4, null, 6 };

            var actual = JoeyAverage(numbers);

            4d.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void average_result_with_decimal_places_source_with_null_value()
        {
            var numbers = new int?[] { 1, 1, null, 4, 4 };

            var actual = JoeyAverage(numbers);

            2.5d.ToExpectedObject().ShouldMatch(actual);
        }

        private double? JoeyAverage(IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var count = 0;
            double result = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.HasValue)
                {
                    result += current.Value;
                    count++;
                }
            }

            return result / count;
        }
    }
}