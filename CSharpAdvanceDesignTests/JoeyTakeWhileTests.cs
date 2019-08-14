using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyTakeWhileTests
    {
        [Test]
        public void take_cards_until_separate_card()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
            };

            var actual = JoeyTakeWhile(cards, item => item.Kind != CardKind.Separate);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void take_cards_while_card_point_less_than_4()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
            };

            var actual = JoeyTakeWhileCardPointLessThan4(cards);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Card> JoeyTakeWhileCardPointLessThan4(IEnumerable<Card> cards)
        {
            return JoeyTakeWhile(cards, c => c.Point < 4);
            //var enumerator = cards.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var item = enumerator.Current;
            //    if (item.Point < 4)
            //    {
            //        yield return item;
            //    }
            //    else
            //    {
            //        yield break;
            //    }
            //}
        }

        private IEnumerable<Card> JoeyTakeWhile(IEnumerable<Card> cards, Func<Card, bool> predicate)
        {
            var enumerator = cards.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
}