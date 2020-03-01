using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public interface IMyOrderedEnumerable : IEnumerable<Employee>
    {
        IMyOrderedEnumerable Append(IComparer<Employee> currentComparer);
    }

    public class MyOrderedEnumerable : IMyOrderedEnumerable
    {
        private readonly IEnumerable<Employee> _source;
        private IComparer<Employee> _untilNowComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> source, IComparer<Employee> untilNowComparer)
        {
            _source = source;
            _untilNowComparer = untilNowComparer;
        }

        public static IEnumerator<Employee> JoeySort(IEnumerable<Employee> employees, IComparer<Employee> comboCompare)
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

                    if (comboCompare.Compare(employee, minElement) < 0)
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
            return JoeySort(_source, _untilNowComparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IMyOrderedEnumerable Append(IComparer<Employee> currentComparer)
        {
            _untilNowComparer = new ComboCompare(_untilNowComparer, currentComparer);
            return this;
        }
    }
}