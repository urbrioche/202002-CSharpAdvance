using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class CombineKeyComparer
    {
        public CombineKeyComparer(Func<Employee, string> firstKeySelector, IComparer<string> firstKeyComparer)
        {
            FirstKeySelector = firstKeySelector;
            FirstKeyComparer = firstKeyComparer;
        }

        public Func<Employee, string> FirstKeySelector { get; private set; }
        public IComparer<string> FirstKeyComparer { get; private set; }

        public int FirstKeyCompareResult(Employee employee, Employee minElement)
        {
            return FirstKeyComparer.Compare(FirstKeySelector(employee), FirstKeySelector(minElement));
        }
    }
}