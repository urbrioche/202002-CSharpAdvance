using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>
    {
        private readonly Dictionary<TKey, List<TElement>> _lookup = new Dictionary<TKey, List<TElement>>();

        public void AddElement(TElement employee, TKey lastName)
        {
            if (!_lookup.TryGetValue(lastName, out _))
            {
                _lookup[lastName] = new List<TElement>();
            }

            _lookup[lastName].Add(employee);
        }


        public IEnumerator<IGrouping<TKey, TElement>> ConvertToMyGrouping()
        {
            var enumerator = _lookup.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;
                yield return new MyGrouping<TKey, TElement>(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            return ConvertToMyGrouping();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}