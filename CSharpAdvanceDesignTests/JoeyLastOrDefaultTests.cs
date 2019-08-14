using System;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using ExpectedObjects;

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
        public void get_last_employee_who_is_manager()
        {
            var employees = new List<Employee>()
            {
                new Employee() {FirstName = "Joey", Role = Role.Manager},
                new Employee() {FirstName = "David", Role = Role.Designer},
                new Employee() {FirstName = "Tom", Role = Role.Manager},
                new Employee() {FirstName = "May", Role = Role.Engineer},
            };
            var actual = JoeyLastOrDefault(employees, item => item.Role == Role.Manager);
            new Employee() {FirstName = "Tom", Role = Role.Manager}.ToExpectedObject().ShouldMatch(actual);
        }

        private Employee JoeyLastOrDefault(IEnumerable<Employee> source, Func<Employee, bool> predicate)
        {
            var enumerator = source.GetEnumerator();

            var defaultResult = default(Employee);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    defaultResult = item;
                }
            }

            return defaultResult;
        }

        private Employee JoeyLastOrDefault(IEnumerable<Employee> source)
        {
            var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                return default(Employee);
            }

            var result = enumerator.Current;
            while (enumerator.MoveNext())
            {
                result = enumerator.Current;
            }

            return result;
        }
    }
}