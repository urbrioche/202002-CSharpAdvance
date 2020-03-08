using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<Employee> JoeySort(this IEnumerable<Employee> employees, IComparer<Employee> comboComparer)
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

        public static MyOrderedEnumerable JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return new MyOrderedEnumerable(employees, combineKeyComparer);
        }

        public static IMyOrderedEnumerable JoeyThenBy<TKey>(this IMyOrderedEnumerable orderedEnumerable,
            Func<Employee, TKey> keySelector)
        {
            IComparer<Employee> combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return orderedEnumerable.Append(combineKeyComparer);
        }
    }
}