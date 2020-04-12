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

        [Test]
        public void compare_two_numbers_equal_diff()
        {
            var first = new List<int> { 3, 2, 2 };
            var second = new List<int> { 3, 2, 1 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void first_longer()
        {
            var first = new List<int> { 3, 2, 1, 0 };
            var second = new List<int> { 3, 2, 1 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void second_longer()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1, 0 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void two_empty_list()
        {
            var first = new List<int>();
            var second = new List<int>();

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void two_list_first_empty()
        {
            var first = new List<int>();
            var second = new List<int> { 1 };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        private bool JoeySequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var sendEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                var firstCurrent = firstEnumerator.Current;
                
                if (sendEnumerator.MoveNext())
                {
                    if (!EqualityComparer<TSource>.Default.Equals(firstCurrent, sendEnumerator.Current))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (sendEnumerator.MoveNext())
            {
                return false;
            }

            return true;

        }
    }
}