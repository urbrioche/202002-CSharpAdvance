﻿using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyCountTests
    {
        [Test]
        public void count_of_numbers()
        {
            var numbers = new[] { 10, 20, 30, 40, 50 };

            var count = JoeyCount(numbers);
            var expected = 5;
            Assert.AreEqual(expected, count);
        }

        private static int JoeyCount<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            var count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
    }
}