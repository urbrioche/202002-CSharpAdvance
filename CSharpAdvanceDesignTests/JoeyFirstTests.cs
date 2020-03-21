using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyFirstTests
    {
        [Test]
        public void get_first_girl()
        {
            var girls = new[]
            {
                new Girl(){Age = 60},
                new Girl(){Age = 20},
                new Girl(){Age = 30},
            };

            var girl = JoeyFirst(girls);
            var expected = new Girl { Age = 60 };

            expected.ToExpectedObject().ShouldEqual(girl);
        }

        [Test]
        public void get_first_girl_when_no_girls()
        {
            var girls = new Girl[]
            {
            };

            TestDelegate action = () => JoeyFirst(girls);
            Assert.Throws<InvalidOperationException>(action);
        }

        private TSource JoeyFirst<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            throw new InvalidOperationException($"{nameof(source)} is empty");
        }
    }
}