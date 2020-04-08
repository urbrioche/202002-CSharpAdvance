using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup<TElement>: IEnumerable<IGrouping<string, TElement>>
    {
        private Dictionary<string, List<TElement>> _lookup = new Dictionary<string, List<TElement>>();

        public void AddElement(TElement employee, string lastName)
        {
            if (_lookup.ContainsKey(lastName))
            {
                _lookup[lastName].Add(employee);
            }
            else
            {
                _lookup.Add(lastName, new List<TElement> { employee });
            }
        }

        public IEnumerator<IGrouping<string, TElement>> ConvertToMyGrouping()
        {
            var lookupEnumerator = _lookup.GetEnumerator();
            while (lookupEnumerator.MoveNext())
            {
                var keyValuePair = lookupEnumerator.Current;
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