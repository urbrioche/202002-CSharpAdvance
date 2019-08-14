using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySkipWhileTests
    {
        [Test]
        public void skip_cards_until_separate_card()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            var actual = JoeySkipWhile(cards);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void skip_cards_when_point_less_than_5()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            var actual = JoeySkipWhilePointLessThan5(cards);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Card> JoeySkipWhilePointLessThan5(IEnumerable<Card> cards)
        {
            var enumerator = cards.GetEnumerator();
            var flag = false;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (item.Point >= 5 || flag)
                {
                    flag = true;
                    yield return item;
                }
            }
        }

        private IEnumerable<Card> JoeySkipWhile(IEnumerable<Card> cards)
        {
            var enumerator = cards.GetEnumerator();
            var isStartingTake = false;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.Kind == CardKind.Separate || isStartingTake)
                {
                    isStartingTake = true;
                    yield return item;
                }
            }
        }
    }
}