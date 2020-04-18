using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyCountTests
    {
        [Test]
        public void count_of_numbers()
        {
            var numbers = new[] { 10, 20, 30, 40, 50 };

            var count = LinqExtensions.JoeyCount(numbers);
            var expected = 5;
            Assert.AreEqual(expected, count);
        }
    }
}