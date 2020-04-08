using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyGrouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly List<TElement> _employees;

        public MyGrouping(TKey key, List<TElement> employees)
        {
            _employees = employees;
            Key = key;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TKey Key { get; }
    }
}