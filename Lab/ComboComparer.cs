using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer<TSource> : IComparer<TSource>
    {
        public ComboComparer(IComparer<TSource> firstComparer, IComparer<TSource> secondComparer)
        {
            FirstComparer = firstComparer;
            SecondComparer = secondComparer;
        }

        public IComparer<TSource> FirstComparer { get; private set; }
        public IComparer<TSource> SecondComparer { get; private set; }

        public int Compare(TSource x, TSource y)
        {
            var firstCompareResult = FirstComparer.Compare(x, y);
            if (firstCompareResult != 0)
            {
                return firstCompareResult;
            }

            return SecondComparer.Compare(x, y);
        }
    }
}