using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class CombineKeyComparer<T>:IComparer<Employee>
    {
        public CombineKeyComparer(Func<Employee, T> keySelector, IComparer<T> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, T> KeySelector { get; set; }
        public IComparer<T> KeyComparer { get; set; }

        public int Compare(Employee x, Employee y)
        {
            return KeyComparer.Compare(KeySelector(x), KeySelector(y));
        }
    }
}