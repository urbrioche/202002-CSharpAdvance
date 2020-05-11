using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public class MyGrouping<TElement> : IGrouping<string, TElement>
    {
        private readonly List<TElement> _employees;

        public MyGrouping(string key, List<TElement> employees)
        {
            Key = key;
            _employees = employees;
        }

        public IEnumerator<TElement> GetEnumerator()
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