using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup : IEnumerable<IGrouping<string, Employee>>
    {
        private readonly Dictionary<string, List<Employee>> _lookup = new Dictionary<string, List<Employee>>();

        public void AddElement(Employee employee)
        {
            if (!_lookup.TryGetValue(employee.LastName, out _))
            {
                _lookup[employee.LastName] = new List<Employee>();
            }

            _lookup[employee.LastName].Add(employee);
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