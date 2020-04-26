using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public interface IMyOrderedEnumerable
    {
        IMyOrderedEnumerable Append(IComparer<Employee> currentComparer);
    }

    public class MyOrderedEnumerable : IEnumerable<Employee>, IMyOrderedEnumerable
    {
        private IComparer<Employee> _untilNowComparer;
        private IEnumerable<Employee> _employees;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> untilNowComparer)
        {
            _employees = employees;
            _untilNowComparer = untilNowComparer;
        }

        public IEnumerator<Employee> GetEnumerator()
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

        public IMyOrderedEnumerable Append(IComparer<Employee> currentComparer)
        {
            _untilNowComparer = new ComboComparer<Employee>(_untilNowComparer, currentComparer);
            return this;
        }
    }
}