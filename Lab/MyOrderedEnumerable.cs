using System;
using System.Collections;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable : IEnumerable<Employee>
    {
        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> comparer)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}