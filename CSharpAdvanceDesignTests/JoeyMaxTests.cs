using NUnit.Framework;
using System.Collections.Generic;

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

        private int JoeyMax(IEnumerable<int> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var num = 0;
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