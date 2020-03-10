using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public interface IMyOrderedEnumerable<TSource> : IEnumerable<TSource>
    {
        MyOrderedEnumerable<TSource> Append(IComparer<TSource> currentComparer);
    }

    public class MyOrderedEnumerable<TSource>: IMyOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> _employees;
        private IComparer<TSource> _untilNowComparer;

        public MyOrderedEnumerable(IEnumerable<TSource> employees, IComparer<TSource> untilNowComparer)
        {
            _employees = employees;
            _untilNowComparer = untilNowComparer;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            //selection sort
            var elements = _employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (_untilNowComparer.Compare(elements[i], minElement) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyOrderedEnumerable<TSource> Append(IComparer<TSource> currentComparer)
        {
            _untilNowComparer = new ComboComparer<TSource>(_untilNowComparer, currentComparer);
            return this;
        }
    }
}