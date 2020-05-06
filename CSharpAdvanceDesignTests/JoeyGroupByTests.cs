using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class MyLookup
    {
        public void AddElement(Dictionary<string, List<Employee>> lookup, Employee employee)
        {
            if (!lookup.TryGetValue(employee.LastName, out _))
            {
                lookup[employee.LastName] = new List<Employee>();
            }

            lookup[employee.LastName].Add(employee);
        }

        public IEnumerable<IGrouping<string, Employee>> ConvertToMyGrouping(Dictionary<string, List<Employee>> lookup)
        {
            var enumerator = lookup.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;
                yield return new MyGrouping(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    [TestFixture]
    public class JoeyGroupByTests
    {
        private readonly MyLookup _myLookup = new MyLookup();

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
            while (enumerator.MoveNext())
            {
                var employee = enumerator.Current;

                _myLookup.AddElement(new Dictionary<string, List<Employee>>(), employee);
            }

            return _myLookup.ConvertToMyGrouping(new Dictionary<string, List<Employee>>());
        }
    }

    internal class MyGrouping : IGrouping<string, Employee>
    {
        private readonly List<Employee> _employees;

        public MyGrouping(string key, List<Employee> employees)
        {
            Key = key;
            _employees = employees;
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