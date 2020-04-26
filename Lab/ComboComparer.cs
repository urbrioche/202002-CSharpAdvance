using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer: IComparer<Employee>
    {
        public ComboComparer(IComparer<Employee> firstCombineKeyComparer, IComparer<Employee> secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public IComparer<Employee> FirstCombineKeyComparer { get; private set; }
        public IComparer<Employee> SecondCombineKeyComparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firsCompareResult = FirstCombineKeyComparer.Compare(x, y);
            if (firsCompareResult != 0)
            {
                return firsCompareResult;
            }
            return SecondCombineKeyComparer.Compare(x, y);
        }
    }
}