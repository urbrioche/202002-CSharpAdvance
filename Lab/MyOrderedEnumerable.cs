using System;
using System.Collections;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable:IEnumerable<Employee>
    {
        private IComparer<Employee> _untilNowComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> untilNowComparer)
        {
            _untilNowComparer = untilNowComparer;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyOrderedEnumerable Append(IComparer<Employee> currentComparer)
        {
            _untilNowComparer = new ComboComparer(_untilNowComparer, currentComparer);
            return this;
        }
    }
}