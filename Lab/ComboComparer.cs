using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer
    {
        public ComboComparer(IComparer<Employee> firstCombineKeyComparer, IComparer<Employee> secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public IComparer<Employee> FirstCombineKeyComparer { get; private set; }
        public IComparer<Employee> SecondCombineKeyComparer { get; private set; }

        public int Compare(Employee employee, Employee minElement)
        {
            var finalCompareResult = 0;
            var firsCompareResult = FirstCombineKeyComparer.Compare(employee, minElement);
            if (firsCompareResult < 0)
            {
                finalCompareResult = firsCompareResult;
            }
            else if (firsCompareResult == 0)
            {
                var secondCompareResult = SecondCombineKeyComparer.Compare(employee, minElement);
                if (secondCompareResult < 0)
                {
                    finalCompareResult = secondCompareResult;
                }
            }

            return finalCompareResult;
        }
    }
}