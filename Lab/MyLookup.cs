using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup<TKey, TElement>: IEnumerable<IGrouping<TKey, TElement>>
    {
        private readonly Dictionary<TKey, List<TElement>> _lookup = new Dictionary<TKey, List<TElement>>();

        public void AddElement(TKey key, TElement element)
        {
            if (_lookup.ContainsKey(key))
            {
                _lookup[key].Add(element);
            }
            else
            {
                _lookup.Add(key, new List<TElement> { element });
            }
        }

        public IEnumerator<IGrouping<TKey, TElement>> ConvertToMyGrouping()
        {
            var lookupEnumerator = _lookup.GetEnumerator();
            while (lookupEnumerator.MoveNext())
            {
                var keyValuePair = lookupEnumerator.Current;
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