using System;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using ExpectedObjects;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyLastOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();
            var actual = JoeyLastOrDefault(employees);
            Assert.IsNull(actual);
        }

        [Test]
        public void get_last_employee()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLastOrDefault(employees);

            new Employee { FirstName = "Cash", LastName = "Li" }
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_employee_last_name_is_Chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLastOrDefaultWithCondition(employees, current => current?.LastName=="Chen");

            new Employee { FirstName = "David", LastName = "Chen" }
            .ToExpectedObject().ShouldMatch(employee);
        }

        private Employee JoeyLastOrDefaultWithCondition(IEnumerable<Employee> employees, Func<Employee, bool> predicate)
        {
            var enumerator = employees.GetEnumerator();
            Employee employee = default(Employee);
            while (enumerator.MoveNext()) 
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    employee = current; 
                } 
            }

            return employee;
        }

        private TSource JoeyLastOrDefault<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return default(TSource);
            }

            var last = enumerator.Current;
            while (enumerator.MoveNext())
            {
                last = enumerator.Current;
            }

            return last;

            //var enumerator = employees.GetEnumerator();
            //var hasMatch = false;
            //Employee employee = null;
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    hasMatch = true;
            //    employee = current;
            //}

            //return hasMatch ? employee : throw new InvalidOperationException();
        }
    }
}