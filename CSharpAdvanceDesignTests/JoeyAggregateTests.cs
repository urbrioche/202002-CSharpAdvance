using System;
using NUnit.Framework;
using System.Collections.Generic;

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

            var actual = JoeyAggregate(drawlingList, balance, (seed, current) => seed = CalculateBalance(seed, current));

            var expected = 10.91m;

            Assert.AreEqual(expected, actual);
        }

        private decimal JoeyAggregate(IEnumerable<int> drawlingList, decimal balance, Func<decimal, int, decimal> calculateBalance)
        {
            var enumerator = drawlingList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                balance = calculateBalance(balance, current);
            }

            return balance;
        }

        private static decimal CalculateBalance(decimal seed, int current)
        {
            if (current <= seed)
            {
                seed = seed - current;
            }

            return seed;
        }
    }
}