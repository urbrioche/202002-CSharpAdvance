using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> JoeyGroupBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var enumerator = source.GetEnumerator();
            var myLookup = new MyLookup<TKey, TSource>();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                myLookup.AddElement(current, keySelector(current));
            }

            return myLookup;
        }

        public static TAccumulate JoeyAggregate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                seed = func(seed, current);
            }

            return seed;
        }

        public static IEnumerable<TResult> JoeyJoin<TOuter, TInner, TKey, TResult>(
            IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            var outerEnumerator = outer.GetEnumerator();
            var comparer = EqualityComparer<TKey>.Default;
            while (outerEnumerator.MoveNext())
            {
                var innerEnumerator = inner.GetEnumerator();
                while (innerEnumerator.MoveNext())
                {
                    if (comparer.Equals(outerKeySelector(outerEnumerator.Current), innerKeySelector(innerEnumerator.Current)))
                    {
                        yield return resultSelector(outerEnumerator.Current, innerEnumerator.Current);
                    }
                }
            }
        }
    }
}