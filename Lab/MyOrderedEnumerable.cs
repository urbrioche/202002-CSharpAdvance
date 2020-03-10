using System;
using System.Collections;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable:IEnumerable<Employee>
    {
        private readonly IComparer<Employee> _combineKeyComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> combineKeyComparer)
        {
            _combineKeyComparer = combineKeyComparer;
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