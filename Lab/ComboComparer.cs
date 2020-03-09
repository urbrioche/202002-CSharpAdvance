using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer:IComparer<Employee>
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
            var firstKeyCompareResult = FirstCombineKeyComparer.Compare(x, y);
            if (firstKeyCompareResult !=0)
            {
                return firstKeyCompareResult;
            }

            return SecondCombineKeyComparer.Compare(x, y);
        }
    }
}