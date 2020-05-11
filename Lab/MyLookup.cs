using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup : IEnumerable<IGrouping<string, Employee>>
    {
        private readonly Dictionary<string, List<Employee>> _lookup = new Dictionary<string, List<Employee>>();

        public void AddElement(Employee employee, string lastName)
        {
            if (!_lookup.TryGetValue(lastName, out _))
            {
                _lookup[lastName] = new List<Employee>();
            }

            _lookup[lastName].Add(employee);
        }


        public IEnumerator<IGrouping<string, Employee>> ConvertToMyGrouping()
        {
            var enumerator = _lookup.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;
                yield return new MyGrouping(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public IEnumerator<IGrouping<string, Employee>> GetEnumerator()
        {
            return ConvertToMyGrouping();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}