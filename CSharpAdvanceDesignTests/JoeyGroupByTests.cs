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

            var actual = employees.JoeyGroupBy(employee => employee.LastName);
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

            var actual = employees.JoeyGroupBy(employee => new { employee.LastName, employee.Role });
            Assert.AreEqual(4, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Manager},
                new Employee {FirstName = "Eric", LastName = "Chen", Role = Role.Manager},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }
    }
}