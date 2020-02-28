using System;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            Console.WriteLine("start where");
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            } 

            //var result = new List<TSource>();
            //foreach (var item in source)
            //{
            //    if (predicate(item))
            //    {
            //        result.Add(item);
            //    }
            //}

            //return result;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(selector(item));
            }

            return result;
        }

        public static List<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
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

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> urls,
            Func<TSource, int, TResult> selector)
        {
            var result = new List<TResult>();

            int index = 0;
            foreach (var item in urls)
            {
                result.Add(selector(item, index));
                index++;
            }

            return result;
        }
    }
}