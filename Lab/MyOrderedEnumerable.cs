using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable : IEnumerable<Employee>
    {
        private readonly IEnumerable<Employee> _employees;
        private readonly IComparer<Employee> _combineKeyComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> combineKeyComparer)
        {
            _employees = employees;
            _combineKeyComparer = combineKeyComparer;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return JoeySort(_employees, _combineKeyComparer);
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator<Employee> JoeySort(IEnumerable<Employee> employees, IComparer<Employee> comboComparer)
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

    }
}