using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
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

        public static IEnumerable<string> JoeySelect(this IEnumerable<string> source,
            Func<string, int, string> selector)
        {
            var index = 0;
            var result = new List<string>();
            foreach (var url in source)
            {
                result.Add(selector(url, index));
                index++;
            }

            return result;
        }

        public static IEnumerable<string> JoeySelectForRemove(this List<Employee> source,
            Func<Employee, string> selector)
        {
            return JoeySelect(source, selector);
            //var result = new List<string>();
            //foreach (var item in source)
            //{
            //    result.Add(selector(item));
            //}

            //return result;
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