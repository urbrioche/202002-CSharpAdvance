using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer<TSource>:IComparer<TSource>
    {
        public ComboComparer(IComparer<TSource> firstCombineKeyComparer, IComparer<TSource> secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public IComparer<TSource> FirstCombineKeyComparer { get; private set; }
        public IComparer<TSource> SecondCombineKeyComparer { get; private set; }

        public int Compare(TSource x, TSource y)
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