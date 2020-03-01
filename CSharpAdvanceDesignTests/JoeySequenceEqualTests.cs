using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySequenceEqualTests
    {
        [Test]
        public void compare_two_numbers_equal()
        {
            var first = new List<int> {3, 2, 1};
            var second = new List<int> {3, 2, 1};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_diff()
        {
            var first = new List<int> {3, 2, 2};
            var second = new List<int> {3, 2, 1};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void first_longer()
        {
            var first = new List<int> {3, 2, 1, 0};
            var second = new List<int> {3, 2, 1};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void second_longer()
        {
            var first = new List<int> {3, 2, 1};
            var second = new List<int> {3, 2, 1, 0};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void two_empty_list()
        {
            var first = new List<int> { };
            var second = new List<int> { };

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void two_empty_list_first_empty()
        {
            var first = new List<int> { };
            var second = new List<int> {1};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsFalse(actual);
        }

        private bool JoeySequenceEqual(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (true)
            {
                var hasFirstCurrent = firstEnumerator.MoveNext();
                var hasSecondCurrent = secondEnumerator.MoveNext();

                //length different
                if (hasFirstCurrent != hasSecondCurrent)
                {
                    return false;
                }

                //both end
                if (hasFirstCurrent == false)
                {
                    return true;
                }

                //different value
                if (firstEnumerator.Current != secondEnumerator.Current)
                {
                    return false;
                }
            }
            //using (var firstEnumerator = first.GetEnumerator())
            //{
            //    using (var secondEnumerator = second.GetEnumerator())
            //    {
            //        while (true)
            //        {
            //            var hasFirstElement = firstEnumerator.MoveNext();
            //            var hasSecondElement = secondEnumerator.MoveNext();

            //            if (!(hasFirstElement && hasSecondElement))
            //            {
            //                return hasFirstElement == hasSecondElement;
            //                //return !(hasFirstElement || hasSecondElement);
            //            }

            //            if (firstEnumerator.Current != secondEnumerator.Current)
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //}
        }
    }
}