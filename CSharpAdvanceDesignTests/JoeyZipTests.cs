﻿using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyZipTests
    {
        [Test]
        public void pair_girls_and_keys()
        {
            var girls = new List<Girl>
            {
                new Girl() {Name = "Mary"},
                new Girl() {Name = "Jessica"},
            };

            var keys = new List<Key>
            {
                new Key() {Type = CardType.BMW, Owner = "Joey"},
                new Key() {Type = CardType.TOYOTA, Owner = "David"},
                new Key() {Type = CardType.Benz, Owner = "Tom"},
            };

            var pairs = JoeyZip(girls, keys, (girl, key) => $"{girl.Name}-{key.Owner}");

            var expected = new[]
            {
                "Mary-Joey",
                "Jessica-David",
            };

            expected.ToExpectedObject().ShouldMatch(pairs);
        }

        private static IEnumerable<TResult> JoeyZip<TFirst, TSecond, TResult>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, 
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}