using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer:IComparer<Employee>
    {
        public ComboComparer(CombineKeyComparer firstCombineKeyComparer, CombineKeyComparer secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public CombineKeyComparer FirstCombineKeyComparer { get; private set; }
        public CombineKeyComparer SecondCombineKeyComparer { get; private set; }

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