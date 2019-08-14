using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

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
                new Girl() {Age = 10},
                new Girl() {Age = 20},
                new Girl() {Age = 30},
            };

            var girl = girls.JoeyFirst();
            var expected = new Girl {Age = 10};

            expected.ToExpectedObject().ShouldMatch(girl);
        }

        [Test]
        public void get_first_girl_when_girls_is_empty()
        {
            var girls = new Girl[] { };

            TestDelegate action = () => girls.JoeyFirst();

            Assert.Throws<InvalidOperationException>(action);
        }
    }
}