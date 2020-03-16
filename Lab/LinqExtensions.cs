using System;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtensions
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
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

        public static List<int> JoeyWhereWithIndex(this List<int> numbers, Func<int, int, bool> predicate)
        {
            var index = 0;
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (predicate(number, index))
                {
                    result.Add(number);
                }
                index++;
            }

            return result;
        }
    }
}