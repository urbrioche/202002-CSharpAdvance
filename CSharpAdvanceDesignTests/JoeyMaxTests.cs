using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyMaxTests
    {
        [Test]
        public void get_max_number()
        {
            var numbers = new[] { 1, 3, 91, 5 };

            var max = numbers.JoeyMax();

            Assert.AreEqual(91, max);
        }


        [Test]
        public void empty_numbers_throw_exception()
        {
            var numbers = Enumerable.Empty<int>();

            TestDelegate action = () => numbers.JoeyMax();

            Assert.Throws<InvalidOperationException>(action);
        }
    }
}