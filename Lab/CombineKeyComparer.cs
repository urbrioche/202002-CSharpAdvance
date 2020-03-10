using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class CombineKeyComparer<TSource, TKey>:IComparer<TSource>
    {
        public CombineKeyComparer(Func<TSource, TKey> keySelector, IComparer<TKey> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<TSource, TKey> KeySelector { get; private set; }
        public IComparer<TKey> KeyComparer { get; private set; }

        public int Compare(TSource x, TSource y)
        {
            return KeyComparer.Compare(KeySelector(x), KeySelector(y));
        }
    }
}