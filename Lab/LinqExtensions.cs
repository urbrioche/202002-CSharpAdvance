using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<Employee> JoeySortBy(this IEnumerable<Employee> employees,
            IComparer<Employee> comboComparer)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (comboComparer.Compare(elements[i], minElement) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        public static IMyOrderedEnumerable<TSource> JoeyOrderBy<TSource, TKey>(this IEnumerable<TSource> employees,
            Func<TSource, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TSource, TKey>(keySelector, Comparer<TKey>.Default);
            return new MyOrderedEnumerable<TSource>(employees, combineKeyComparer);
        }

        public static IMyOrderedEnumerable<TSource> JoeyThenBy<TSource, TKey>(this IMyOrderedEnumerable<TSource> myOrderedEnumerable,
            Func<TSource, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TSource, TKey>(keySelector, Comparer<TKey>.Default);
            return myOrderedEnumerable.Append(combineKeyComparer);
        }


    }
}