using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class MyOrderedEnumerable
    {
        private readonly IEnumerable<Employee> _employees;
        private readonly IComparer<Employee> _combineKeyComparer;

        public MyOrderedEnumerable(IEnumerable<Employee> employees, IComparer<Employee> combineKeyComparer)
        {
            _employees = employees;
            _combineKeyComparer = combineKeyComparer;
        }
    }
}