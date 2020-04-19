using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyMaxTests
    {
        [Test]
        public void get_max_number()
        {
            var numbers = new[] { 1, 3, 91, 5 };

            var max = JoeyMax(numbers);

            Assert.AreEqual(91, max);
        }


        [Test]
        public void empty_numbers_throw_exception()
        {
            var numbers = Enumerable.Empty<int>();

            TestDelegate action = () => JoeyMax(numbers);

            Assert.Throws<InvalidOperationException>(action);
        }


        private static int JoeyMax(IEnumerable<int> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }
            var num = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (current > num)
                {
                    num = current;
                }
            }

            return num;
        }
    }
}