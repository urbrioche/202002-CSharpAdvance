using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public interface IMyOrderedEnumerable : IEnumerable<TSource>
    {
        IMyOrderedEnumerable Append(IComparer<TSource> currentComparer);
    }

    public class MyOrderedEnumerable : IMyOrderedEnumerable
    {
        private readonly IEnumerable<TSource> _source;
        private IComparer<TSource> _untilNowComparer;

        public MyOrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> untilNowComparer)
        {
            _source = source;
            _untilNowComparer = untilNowComparer;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return JoeySort(_source, _untilNowComparer);
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator<TSource> JoeySort(IEnumerable<TSource> source, IComparer<TSource> comboComparer)
        {
            //selection sort
            var elements = source.ToList();
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

        public IMyOrderedEnumerable Append(IComparer<TSource> currentComparer)
        {
            _untilNowComparer = new ComboComparer(_untilNowComparer, currentComparer);
            return this;
        }
    }
}