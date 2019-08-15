using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyWhereWithDefaultTests
    {
        [Test]
        public void default_employee_is_Joey()
        {
            var employees = new List<Employee>
            {
                new Employee() {FirstName = "Tom", LastName = "Li", Role = Role.Engineer},
                new Employee() {FirstName = "David", LastName = "Wang", Role = Role.Designer},
            };

            var actual = WhereWithDefault(
                employees,
                e => e.Role == Role.Manager,
                new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer});

            var expected = new List<Employee>
                {new Employee() {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer}};

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> WhereWithDefault(IEnumerable<Employee> employees, Func<Employee, bool> predicate,
            Employee defaultEmployee)
        {
            var enumerator = employees.GetEnumerator();

            bool hasEmployee = false;
            while (enumerator.MoveNext())
            {
                var employee = enumerator.Current;

                if (predicate(employee))
                {
                    hasEmployee = true;
                    yield return employee;
                }
            }

            if (!hasEmployee)
            {
                yield return defaultEmployee;
            }
        }
    }
}