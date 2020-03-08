using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer:IComparer<TSource>
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
            if (firstCompareResult !=0)
            {
                return firstCompareResult;
            }

            return SecondComparer.Compare(x, y);

            //int finalCompareResult = 0;
            //var firstCompareResult = FirstComparer.Compare(x, y);
            //if (firstCompareResult < 0)
            //{
            //    finalCompareResult = firstCompareResult;
            //    //y = x;
            //    //index = i;
            //}
            //else if (firstCompareResult == 0)
            //{
            //    var secondCompareResult = SecondComparer.Compare(x, y);
            //    if (secondCompareResult < 0)
            //    {
            //        finalCompareResult = secondCompareResult;
            //        //y = x;
            //        //index = i;
            //    }
            //}

            //return finalCompareResult;
        }
    }
}