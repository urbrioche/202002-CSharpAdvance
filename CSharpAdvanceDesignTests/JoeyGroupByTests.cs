using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class MyLookup : IEnumerable<IGrouping<string, Employee>>
    {
        private readonly Dictionary<string, List<Employee>> _lookup = new Dictionary<string, List<Employee>>();

        public void AddElement(Employee employee)
        {
            if (_lookup.ContainsKey(employee.LastName))
            {
                _lookup[employee.LastName].Add(employee);
            }
            else
            {
                _lookup.Add(employee.LastName, new List<Employee> {employee});
            }
        }

        public IEnumerable<IGrouping<string, Employee>> ConvertToMyGrouping()
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [TestFixture]
    public class JoeyGroupByTests
    {
        [Test]
        public void groupBy_lastName()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Lee"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Lee"},
            };

            var actual = JoeyGroupBy(employees);
            Assert.AreEqual(2, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        private IEnumerable<IGrouping<string, Employee>> JoeyGroupBy(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            var myLookup = new MyLookup();
            while (enumerator.MoveNext())
            {
                var employee = enumerator.Current;

                myLookup.AddElement(employee);
            }

            return myLookup;
            //return myLookup.ConvertToMyGrouping();
        }
    }

    internal class MyGrouping : IGrouping<string, Employee>
    {
        private readonly List<Employee> _employees;

        public MyGrouping(string key, List<Employee> employees)
        {
            _employees = employees;
            this.Key = key;
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