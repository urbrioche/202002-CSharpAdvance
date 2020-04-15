using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [Ignore("not yet")]
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

            var actual = JoeyAggregate(drawlingList, balance, (seed, current) =>
            {
                decimal seed1 = seed;
                if (current <= seed1)
                {
                    seed1 = seed1 - current;
                }

                return seed1;
            });

            var expected = 10.91m;

            Assert.AreEqual(expected, actual);
        }

        private decimal JoeyAggregate(IEnumerable<int> drawlingList, decimal balance, Func<decimal, int, decimal> calculateBalance)
        {
            var enumerator = drawlingList.GetEnumerator();
            var seed = balance;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                seed = calculateBalance(seed, current);
            }

            return seed;
        }
    }
}