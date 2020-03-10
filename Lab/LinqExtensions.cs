using System;
using System.Collections.Generic;
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

        public static IEnumerable<Employee> JoeyOrderBy<TKey>(this IEnumerable<Employee> employees, 
            Func<Employee, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return new MyOrderedEnumerable(employees, combineKeyComparer);
        }

        public static IEnumerable<Employee> JoeyThenBy<TKey>(this MyOrderedEnumerable myOrderedEnumerable, 
            Func<Employee, TKey> keySelector)
        {
            return myOrderedEnumerable;
        }


    }
}