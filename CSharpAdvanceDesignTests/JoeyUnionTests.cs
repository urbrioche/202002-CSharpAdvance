using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

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

            var actual = JoeyUnion(first, second);
            var expected = new[] {1, 3, 5, 7};

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            var enumerator = first.GetEnumerator();
            var hashSet = new HashSet<int>();

            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                if (hashSet.Add(firstItem))
                {
                    yield return firstItem;
                }
            }

            var secondEnumerator = second.GetEnumerator();
            while (secondEnumerator.MoveNext())
            {
                var secondItem = secondEnumerator.Current;
                if (hashSet.Add(secondItem))
                {
                    yield return secondItem;
                }
            }
        }
    }
}