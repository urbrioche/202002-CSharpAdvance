using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup<TElement> : IEnumerable<IGrouping<string, TElement>>
    {
        private readonly Dictionary<string, List<TElement>> _lookup = new Dictionary<string, List<TElement>>();

        public void AddElement(TElement employee, string lastName)
        {
            if (!_lookup.TryGetValue(lastName, out _))
            {
                _lookup[lastName] = new List<TElement>();
            }

            _lookup[lastName].Add(employee);
        }


        public IEnumerator<IGrouping<string, TElement>> ConvertToMyGrouping()
        {
            var enumerator = _lookup.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;
                yield return new MyGrouping<TElement>(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public IEnumerator<IGrouping<string, TElement>> GetEnumerator()
        {
            return ConvertToMyGrouping();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}