using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> JoeySort(this IEnumerable<TSource> employees, IComparer<TSource> comboComparer)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];

                    if (comboComparer.Compare(employee, minElement) < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        public static IMyOrderedEnumerable JoeyOrderBy<TKey>(this IEnumerable<TSource> employees,
            Func<TSource, TKey> keySelector)
        {
            IComparer<TSource> combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return new MyOrderedEnumerable(employees, combineKeyComparer);
        }

        public static IMyOrderedEnumerable JoeyThenBy<TKey>(this IMyOrderedEnumerable orderedEnumerable,
            Func<TSource, TKey> keySelector)
        {
            IComparer<TSource> combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return orderedEnumerable.Append(combineKeyComparer);
        }
    }
}