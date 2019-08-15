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
            var numbers = new int?[] {1, 1, null, 4, 4};

            var actual = JoeyAverage(numbers);

            2.5d.ToExpectedObject().ShouldMatch(actual);
        }

        private double? JoeyAverage(IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var result = 0;
            var count = 0;
            while (enumerator.MoveNext())
            {
                var number = enumerator.Current;
                if (number.HasValue)
                {
                    result += number.Value;
                    count++;
                }
            }

            return result / (double) count;
        }
    }
}