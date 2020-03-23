using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ExpectedObjects;
using Lab;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySingleTests
    {
        [Test]
        public void no_girls()
        {
            var girls = new Girl[] { };
            TestDelegate action = () => LinqExtensions.JoeySingle(girls);
            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void only_one_girl()
        {
            var girls = new Girl[]
            {
                new Girl() {Name = "May"},
            };
            var girl = LinqExtensions.JoeySingle(girls);

            new Girl() {Name = "May"}.ToExpectedObject().ShouldMatch(girl);
        }

        [Test]
        public void more_than_one_girl()
        {
            var girls = new Girl[]
            {
                new Girl() {Name = "May"},
                new Girl() {Name = "Jessica"},
            };
            TestDelegate action = () => LinqExtensions.JoeySingle(girls);
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}