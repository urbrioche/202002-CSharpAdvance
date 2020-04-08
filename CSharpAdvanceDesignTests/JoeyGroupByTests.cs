using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
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

            var actual = JoeyGroupBy(employees, employee => employee.LastName);
            Assert.AreEqual(2, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        [Test]
        public void groupBy_lastName_role()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Manager},
                new Employee {FirstName = "Tom", LastName = "Lee", Role = Role.Engineer},
                new Employee {FirstName = "Eric", LastName = "Chen", Role = Role.Manager},
                new Employee {FirstName = "John", LastName = "Chen", Role = Role.Designer},
                new Employee {FirstName = "David", LastName = "Lee", Role = Role.Designer},
            };

            var actual = JoeyGroupBy(employees, employee => new { employee.LastName, employee.Role });
            Assert.AreEqual(4, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Manager},
                new Employee {FirstName = "Eric", LastName = "Chen", Role = Role.Manager},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        private IEnumerable<IGrouping<TKey, TSource>> JoeyGroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var enumerator = source.GetEnumerator();
            var myLookup = new MyLookup<TKey, TSource>();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                myLookup.AddElement(keySelector(current), current);
            }

            return myLookup;
        }
    }
}