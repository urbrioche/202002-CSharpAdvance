using System;
using System.Collections.Generic;
using ExpectedObjects;
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
            TestDelegate action = () => JoeySingle(girls);
            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void only_one_girl()
        {
            var girls = new Girl[]
            {
                new Girl() {Name = "May"},
            };
            var girl = JoeySingle(girls);

            new Girl() { Name = "May" }.ToExpectedObject().ShouldMatch(girl);
        }

        [Test]
        public void more_than_one_girl()
        {
            var girls = new Girl[]
            {
                new Girl() {Name = "May"},
                new Girl() {Name = "Jessica"},
            };
            TestDelegate action = () => JoeySingle(girls);
            Assert.Throws<InvalidOperationException>(action);
        }

        private Girl JoeySingle(IEnumerable<Girl> girls)
        {
            throw new System.NotImplementedException();
        }
    }
}