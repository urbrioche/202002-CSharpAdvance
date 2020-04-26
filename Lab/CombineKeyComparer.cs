using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class CombineKeyComparer
    {
        public CombineKeyComparer(Func<Employee, string> keySelector, IComparer<string> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, string> KeySelector { get; private set; }
        public IComparer<string> KeyComparer { get; private set; }

        public int Compare(Employee employee, Employee minElement)
        {
            return KeyComparer.Compare(KeySelector(employee), KeySelector(minElement));
        }

        public int SecondCompareResult(Employee employee, Employee minElement)
        {
            return Compare(employee, minElement);
        }
    }
}