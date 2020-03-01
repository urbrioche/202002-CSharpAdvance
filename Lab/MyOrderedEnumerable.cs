using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable : IEnumerable<Employee>
    {
        private readonly IEnumerable<Employee> _source;
        private readonly IComparer<Employee> _combineKeyComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> source, IComparer<Employee> combineKeyComparer)
        {
            _source = source;
            _combineKeyComparer = combineKeyComparer;
        }

        public static IEnumerable<Employee> JoeySort(IEnumerable<Employee> employees,
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

        public IEnumerator<Employee> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyOrderedEnumerable Append(IComparer<Employee> combineKeyComparer)
        {
            throw new System.NotImplementedException();
        }
    }
}