using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer<TSource>: IComparer<TSource>
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
            var firsCompareResult = FirstCombineKeyComparer.Compare(x, y);
            if (firsCompareResult != 0)
            {
                return firsCompareResult;
            }
            return SecondCombineKeyComparer.Compare(x, y);
        }
    }
}