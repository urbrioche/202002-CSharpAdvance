using System;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<string> JoeySelect(this IEnumerable<string> urls, Func<string, string> selector)
        {
            var result = new List<string>();
            foreach (var url in urls)
            {
                result.Add(selector(url));
            }

            return result;
        }

        public static IEnumerable<string> JoeySelect(this IEnumerable<string> urls, Func<string, int, string> selector)
        {
            var index = 0;
            var result = new List<string>();
            foreach (var url in urls)
            {
                result.Add(selector(url, index));
                index++;
            }

            return result;
        }

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

        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            var result = new List<TSource>();
            foreach (var item in source)
            {
                if (predicate(item, index))
                {
                    result.Add(item);
                }

                index++;
            }

            return result;
        }
    }
}