using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable<TSource> : IEnumerable<TSource>, IOrderedEnumerable<TSource>
    {
        private readonly IComparer<TSource> _comparer;
        private readonly IEnumerable<TSource> _employees;

        public MyOrderedEnumerable(IEnumerable<TSource> employees, IComparer<TSource> comparer)
        {
            _employees = employees;
            _comparer = comparer;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return GetOrderedEnumerable();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer, bool @descending)
        {
            return CreateOrderedEnumerable(keySelector, comparer);
        }

        public IEnumerator<TSource> GetOrderedEnumerable()
        {
            //bubble sort
            var elements = _employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var currentElement = elements[i];

                    var finalCompareResult = _comparer.Compare(currentElement, minElement);

                    if (finalCompareResult < 0)
                    {
                        minElement = currentElement;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        private IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            var nextComparer = new CombineKeyComparer<TSource, TKey>(keySelector, comparer);

            return new MyOrderedEnumerable<TSource>(
                _employees, new ComboComparer<TSource>(_comparer, nextComparer));
        }
    }
}