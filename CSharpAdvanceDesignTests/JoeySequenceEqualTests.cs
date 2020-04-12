using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        private bool JoeySequenceEqual(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var sendEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                var firstCurrent = firstEnumerator.Current;
                if (sendEnumerator.MoveNext())
                {
                    if (firstCurrent != sendEnumerator.Current)
                    {
                        return false;
                    }

                }
            }

            return true;

        }
    }
}