using System;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAggregateTests
    {
        [Test]
        public void drawling_money_that_balance_have_to_be_positive()
        {
            var balance = 100.91m;

            var drawlingList = new List<int>
            {
                30, 80, 20, 40, 25
            };

            var actual = drawlingList.JoeyAggregate(balance, (seed, current) =>
            {
                if (current <= seed)
                {
                    seed -= current;
                }

                return seed;
            });

            var expected = 10.91m;

            Assert.AreEqual(expected, actual);
        }
    }
}