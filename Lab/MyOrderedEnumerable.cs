using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable : IEnumerable<Employee>
    {
        private readonly IComparer<Employee> _comparer;
        private readonly IEnumerable<Employee> _employees;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> comparer)
        {
            _employees = employees;
            _comparer = comparer;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return GetOrderedEnumerable();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Employee> GetOrderedEnumerable()
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
    }
}