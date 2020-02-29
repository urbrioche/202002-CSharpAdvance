using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyLastTests
    {
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

            var employee = JoeyLast(employees);

            new Employee { FirstName = "Cash", LastName = "Li" }
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"},
            };

            var employee = JoeyLastWithCondition(employees);

            new Employee { FirstName = "David", LastName = "Chen" }
            .ToExpectedObject().ShouldMatch(employee);
        }

        private Employee JoeyLastWithCondition(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void get_last_employee_when_no_girls()
        {
            var employees = new Employee[]
            {
            };

            TestDelegate action = () => JoeyLast(employees);
            Assert.Throws<InvalidOperationException>(action);
        }

        private Employee JoeyLast(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var last = enumerator.Current;
            while (enumerator.MoveNext())
            {
                last = enumerator.Current;
            }

            return last;
        }
    }
}