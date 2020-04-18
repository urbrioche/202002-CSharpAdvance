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

        private IEnumerable<string> JoeyZip(IEnumerable<Girl> girls, IEnumerable<Key> keys, Func<Girl, Key, string> resultSelector)
        {
            var girlEnumerator = girls.GetEnumerator();
            var keyEnumerator = keys.GetEnumerator();
            while (girlEnumerator.MoveNext() && keyEnumerator.MoveNext())
            {
                var girl = girlEnumerator.Current;
                var key = keyEnumerator.Current;
                yield return resultSelector(girl, key);
            }
        }
    }
}