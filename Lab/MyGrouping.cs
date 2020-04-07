using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyGrouping : IGrouping<string, Employee>
    {
        private readonly List<Employee> _employees;

        public MyGrouping(string key, List<Employee> employees)
        {
            _employees = employees;
            Key = key;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Key { get; }
    }
}