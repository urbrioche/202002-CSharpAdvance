using System;
using System.Collections.Generic;
using System.Configuration;
using ExpectedObjects;
using Lab;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyLastTests
    {
        [Test]
        public void get_last_number()
        {
            var numbers = new[] {1, 2, 3, 4};
            var actual = numbers.JoeyLast();
            4.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_last_number_when_empty()
        {
            var numbers = new int[] { };
            TestDelegate action = () => numbers.JoeyLast();
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}