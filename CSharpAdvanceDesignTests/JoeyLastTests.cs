using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab;
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

            var employee = employees.JoeyLast();

            new Employee {FirstName = "Cash", LastName = "Li"}
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

            var employee = employees.JoeyLast(current => current?.LastName=="Chen");

            new Employee {FirstName = "David", LastName = "Chen"}
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_employee_when_no_girls()
        {
            var employees = new Employee[]
            {
            };

            TestDelegate action = () => employees.JoeyLast();
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}