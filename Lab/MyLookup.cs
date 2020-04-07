using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyLookup: IEnumerable<IGrouping<string, Employee>>
    {
        private Dictionary<string, List<Employee>> _lookup = new Dictionary<string, List<Employee>>();

        public void AddElement(Employee employee)
        {
            if (_lookup.ContainsKey(employee.LastName))
            {
                _lookup[employee.LastName].Add(employee);
            }
            else
            {
                _lookup.Add(employee.LastName, new List<Employee> { employee });
            }
        }

        public IEnumerator<IGrouping<string, Employee>> ConvertToMyGrouping()
        {
            var lookupEnumerator = _lookup.GetEnumerator();
            while (lookupEnumerator.MoveNext())
            {
                var keyValuePair = lookupEnumerator.Current;
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