using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return JoeyWhere(source, (item, index) => predicate(item));
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(selector(item));
            }

            return result;
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current, index))
                {
                    yield return current;
                }

                index++;
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            var index = 0;
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(selector(item, index));
                index++;
            }

            return result;
        }
    }
}